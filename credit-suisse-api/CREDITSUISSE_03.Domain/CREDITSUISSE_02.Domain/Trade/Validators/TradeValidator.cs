using System;
using FluentValidation;
using CREDITSUISSE_03.Domain.Trade.Commands.Main;

namespace CREDITSUISSE_03.Domain.Trade.Validators.Main
{
    public abstract class TradeValidator<T> : AbstractValidator<T> where T : TradeCommand
    {
        protected void ValidateTrade()
        {
            RuleFor(x => x.NextPaymentDate)
            .NotNull();
        }
    }
}