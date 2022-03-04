using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CREDITSUISSE_03.Domain.Trade.Commands.Main;
using CREDITSUISSE_03.Domain.Trade.Events.Main;
using CREDITSUISSE_03.Domain.Trade.Interfaces;
using CREDITSUISSE_03.Domain.Trade.Models;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Handlers;
using CREDITSUISSE_04.Core.Interfaces;
using CREDITSUISSE_04.Core.Notifications;
using System.Collections.Generic;

namespace CREDITSUISSE_03.Domain.Trade.Handlers.Main
{
    public class TradeCommandHandler : CommandHandler, IRequestHandler<TradeCategorizeCommand, bool>
    {
        private readonly ITradeRepository _repository;
        private readonly IMediatorHandler _bus;
        public TradeCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ITradeRepository repository) : base(bus, notifications)
        {
            _repository = repository;
            _bus = bus;
        }

        public async Task<bool> Handle(TradeCategorizeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            if(request.NextPaymentDate.AddDays(-30) < request.ReferenceDate)
                CategoryModel.Description = "EXPIRED";
            else if(request.Value > 1000000 && request.ClientSector.ToLower() == "private")
                CategoryModel.Description = "HIGHRISK";
            else if(request.Value > 1000000 && request.ClientSector.ToLower() == "public")
                CategoryModel.Description = "MEDIUMRISK";

            return await Task.FromResult<bool>(true);
        }
    }
}