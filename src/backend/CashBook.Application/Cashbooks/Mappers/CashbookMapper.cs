using AutoMapper;
using CashBook.Application.Cashbooks.Commands;
using CashBook.Domain.Entities;

namespace CashBook.Application.Cashbooks.Mappers;

public class CashbookMapper : Profile
{
    public CashbookMapper()
    {
        CreateMap<CreateCashbookCommand, Cashbook>()
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.CashbookName));

        CreateMap<UpdateCashbookCommand, Cashbook>()
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.CashbookName));
    }
}