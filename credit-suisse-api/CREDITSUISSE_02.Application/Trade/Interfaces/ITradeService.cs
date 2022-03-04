using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CREDITSUISSE_02.Application.Trade.Dtos;

namespace CREDITSUISSE_02.Application.Trade.Interfaces
{
    public interface ITradeService
    {
        Task<IEnumerable<TradeDto>> GetAllCategorized();
        Task Test();
    }
}