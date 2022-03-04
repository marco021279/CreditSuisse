using AutoMapper;
using CREDITSUISSE_03.Domain.Trade.Models;
using CREDITSUISSE_02.Application.Trade.Dtos;

namespace CREDITSUISSE_02.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<TradeModel, TradeDto>();
            CreateMap<TradeDto, TradeModel>();
        }

    }
}