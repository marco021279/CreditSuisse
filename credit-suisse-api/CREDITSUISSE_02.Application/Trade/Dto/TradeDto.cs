using System;

namespace CREDITSUISSE_02.Application.Trade.Dtos
{
    public class TradeDto
    {
        public DateTime ReferenceDate { get; set; }
        public int BusinessNumber { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public string Category { get; set; }
    }
}