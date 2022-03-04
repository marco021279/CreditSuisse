using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CREDITSUISSE_03.Domain.Trade.Models;
using CREDITSUISSE_04.Core.Interfaces;

namespace CREDITSUISSE_03.Domain.Trade.Interfaces
{
    public interface ITradeRepository
    {
        Task<IEnumerable<TradeModel>> GetAllCategorized();
    }
}