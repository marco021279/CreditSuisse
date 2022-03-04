using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CREDITSUISSE_03.Domain.Trade.Events.Main;

namespace CREDITSUISSE_03.Domain.Trade.Handlers.Main
{
    public class TradeEventHandler : INotificationHandler<TradeCategorizedEvent>
    {
        public Task Handle(TradeCategorizedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        
        //insert anoter handles example: for update a trade
        //public Task Handle(TradeUpdatedEvent notification, CancellationToken cancellationToken)
        
    }
}