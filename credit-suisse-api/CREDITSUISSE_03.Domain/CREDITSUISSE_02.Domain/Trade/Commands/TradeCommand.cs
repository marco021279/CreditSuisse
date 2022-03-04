using System;
using CREDITSUISSE_04.Core.Commands;

namespace CREDITSUISSE_03.Domain.Trade.Commands.Main
{
    public abstract class TradeCommand: Command
    {
        public double Value { get; protected set; }
        public string ClientSector { get; protected set; }
        public DateTime NextPaymentDate { get; protected set; }
        public string Category { get; protected set; }
        public DateTime ReferenceDate { get; protected set; }
        public int BusinessNumber { get; protected set; }
    }
}