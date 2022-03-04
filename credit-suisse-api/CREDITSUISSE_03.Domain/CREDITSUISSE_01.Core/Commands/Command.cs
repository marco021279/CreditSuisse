using System;
using FluentValidation.Results;
using CREDITSUISSE_04.Core.Messages;

namespace CREDITSUISSE_04.Core.Commands
{
    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}