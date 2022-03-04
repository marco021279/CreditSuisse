using System;
using CREDITSUISSE_04.Core.Events;

namespace CREDITSUISSE_03.Domain.Trade.Events.Main
{
    public class TradeCategorizedEvent: Event
    {
        public TradeCategorizedEvent(double value,
                                      string clientSector,
                                      DateTime nextPaymentDate,
                                      string category,
                                      DateTime referenceDate,
                                      int businessNumber)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
            Category = category;
            ReferenceDate = referenceDate;
            BusinessNumber = businessNumber;
        }

        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }
        public string Category { get; private set; }
        public DateTime ReferenceDate { get; private set; }
        public int BusinessNumber { get; private set; }
    }
}