using System;
using MediatR;

namespace CREDITSUISSE_04.Core.Messages
{
    public abstract class Message : IRequest<bool>
    {
        public Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; set; }
    }
}