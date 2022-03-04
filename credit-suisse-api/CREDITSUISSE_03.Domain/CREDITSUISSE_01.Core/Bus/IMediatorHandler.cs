using System.Threading.Tasks;
using CREDITSUISSE_04.Core.Commands;
using CREDITSUISSE_04.Core.Events;

namespace CREDITSUISSE_04.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}