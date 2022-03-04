using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Notifications;

namespace CREDITSUISSE_01.Services.Shared
{
    public class ApiController: ControllerBase {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        public ApiController (INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) {
            _notifications = (DomainNotificationHandler) notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications ();

        protected bool IsValidOperation () {
            return (!_notifications.HasNotifications ());
        }

        protected string[] GetNotifications () {
            return _notifications.GetNotifications ().Select (x => x.Value).ToArray ();
        }

        protected void ClearNotifications () {
            _notifications.Dispose ();
        }

        protected new IActionResult Response (object result = null, string message = null) {
            if (IsValidOperation ()) {
                return Ok (new {
                    result,
                    message = message == null ? new string[] { } : message.Split ('|')
                });
            }

            return BadRequest (new {
                result = string.Empty,
                    message = _notifications.GetNotifications ().Select (n => n.Value)
            });
        }

        protected void NotifyModelStateErrors () {
            var erros = ModelState.Values.SelectMany (v => v.Errors);
            foreach (var erro in erros) {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError (string.Empty, erroMsg);
            }
        }

        protected void NotifyError (string code, string message) {
            _mediator.RaiseEvent (new DomainNotification (code, message));
        }
    }
}