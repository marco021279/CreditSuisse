

using System.Threading.Tasks;
using MediatR;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Commands;
using CREDITSUISSE_04.Core.Interfaces;
using CREDITSUISSE_04.Core.Notifications;

namespace CREDITSUISSE_04.Core.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(command.MessageType, error.ErrorMessage));
            }
        }

        protected void Notify(DomainNotification notification)
        {
            _bus.RaiseEvent(notification);
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (!_notifications.HasNotifications()) return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "Houve um problema ao salvar os dados."));
            return false;
        }
    }
}