using System.Threading.Tasks;
using MediatR;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Commands;
using CREDITSUISSE_04.Core.Events;

namespace CREDITSUISSE_07.Bus
{
    public class MediatorHandler: IMediatorHandler {
        private readonly IMediator _mediator;

        public MediatorHandler (IMediator mediator) {
            _mediator = mediator;
        }

        public Task SendCommand<T> (T command) where T : Command {
            return _mediator.Send (command);
        }

        public Task RaiseEvent<T> (T @event) where T : Event {

            return _mediator.Publish (@event);
        }
    }
}