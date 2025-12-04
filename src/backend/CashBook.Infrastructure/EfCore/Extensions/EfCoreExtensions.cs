using CashBook.Domain.Common.Entities;
using CashBook.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Infrastructure.EfCore.Extensions;

public static class EfCoreExtensions
{
    private static IQueryable<TSource> ApplyTrackingMode<TSource>(
        this IQueryable<TSource> source,
        QueryTrackingMode trackingMode) where TSource : EntityBase
    {
        return trackingMode switch
        {
            QueryTrackingMode.AsTracking => source,
            QueryTrackingMode.AsNoTracking => source.AsNoTracking(),
            QueryTrackingMode.AsNoTrackingWithIdentityResolution => source.AsNoTrackingWithIdentityResolution(),
            _ => source
        };
    }

    public static IQueryable<TSource> ApplyQueryOptions<TSource>(
        this IQueryable<TSource> source,
        QueryOptions queryOptions) where TSource : EntityBase
    {
        return source.ApplyTrackingMode(queryOptions.TrackingMode);
    }
}