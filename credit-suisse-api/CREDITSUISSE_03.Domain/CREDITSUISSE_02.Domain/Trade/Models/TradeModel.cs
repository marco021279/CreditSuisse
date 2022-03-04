using System;
using CREDITSUISSE_04.Core.Models;

namespace CREDITSUISSE_03.Domain.Trade.Models
{
    public class TradeModel : Entity
    {
        public TradeModel() { }

        public TradeModel(double value,
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

        public void UpdateTrade(double value,
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

        public void UpdateCategory(string category)
        {
            Category = category;
        }
    }
}