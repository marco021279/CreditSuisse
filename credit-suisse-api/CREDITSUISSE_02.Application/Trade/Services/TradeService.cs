using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CREDITSUISSE_02.Application.Trade.Dtos;
using CREDITSUISSE_02.Application.Trade.Interfaces;
using CREDITSUISSE_03.Domain.Trade.Commands.Main;
using CREDITSUISSE_03.Domain.Trade.Interfaces;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_03.Domain.Trade.Models;

namespace CREDITSUISSE_02.Application.Trade.Services
{
    public class TradeService : ITradeService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly ITradeRepository _repository;

        public TradeService(IMediatorHandler bus, IMapper mapper, ITradeRepository repository)
        {
            _bus = bus;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Test()
        {
            try
            {
                var dto = new TradeDto{
                    Value = 0,
                    ClientSector = "",
                    NextPaymentDate = new DateTime()
                    
                };
                var command = _mapper.Map<TradeCategorizeCommand>(dto);
                await _bus.SendCommand(command);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<TradeDto>> GetAllCategorized()
        {
            var result = await _repository.GetAllCategorized();

            foreach(var i in result)
            {
                var command = _mapper.Map<TradeCategorizeCommand>(_mapper.Map<TradeDto>(i));
                await _bus.SendCommand(command);
                i.UpdateCategory(CategoryModel.Description);
            }            
            return _mapper.Map<IEnumerable<TradeDto>>(result);
        }
    }
}