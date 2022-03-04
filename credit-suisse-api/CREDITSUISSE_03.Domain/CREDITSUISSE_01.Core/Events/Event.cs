using System;
using MediatR;
using CREDITSUISSE_04.Core.Messages;

namespace CREDITSUISSE_04.Core.Events
{
    public abstract class Event : Message, INotification
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; private set; }
    }
}