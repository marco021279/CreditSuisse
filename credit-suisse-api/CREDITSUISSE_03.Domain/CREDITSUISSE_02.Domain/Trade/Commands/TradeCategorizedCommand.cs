using CREDITSUISSE_03.Domain.Trade.Validators.Main;
using System;

namespace CREDITSUISSE_03.Domain.Trade.Commands.Main
{
    public class TradeCategorizeCommand : TradeCommand
    {
        public TradeCategorizeCommand(double value,
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

        public override bool IsValid()
        {
            ValidationResult = new TradeCategorizeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}