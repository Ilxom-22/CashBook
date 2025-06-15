using CashBook.Domain.Entities;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Persistence.Repositories;

public class CategoryRepository(AppDbContext context) 
    : EntityRepositoryBase<AppDbContext, Category>(context),
        ICategoryRepository
{
    
}