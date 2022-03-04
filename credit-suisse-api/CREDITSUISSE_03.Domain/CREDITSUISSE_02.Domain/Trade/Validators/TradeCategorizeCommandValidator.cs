using CREDITSUISSE_03.Domain.Trade.Commands.Main;

namespace CREDITSUISSE_03.Domain.Trade.Validators.Main
{
    public class TradeCategorizeCommandValidator : TradeValidator<TradeCategorizeCommand>
    {
        public TradeCategorizeCommandValidator()
        {
            ValidateTrade();
        }
    }
}