using AutoMapper;
using CREDITSUISSE_02.Application.Trade.Dtos;
using CREDITSUISSE_03.Domain.Trade.Commands.Main;

namespace CREDITSUISSE_02.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            #region Trade

            CreateMap<TradeDto, TradeCategorizeCommand>()
            .ConstructUsing(x => new TradeCategorizeCommand(x.Value, x.ClientSector, x.NextPaymentDate, x.Category, x.ReferenceDate, x.BusinessNumber));
            
            #endregion
        }
    }
}