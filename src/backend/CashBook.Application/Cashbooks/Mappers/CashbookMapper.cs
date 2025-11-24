using AutoMapper;
using CashBook.Application.Cashbooks.Commands.CreateCashbook;
using CashBook.Application.Cashbooks.Commands.UpdateCashbook;
using CashBook.Domain.Entities.Cashbooks;

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