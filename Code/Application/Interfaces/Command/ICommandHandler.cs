using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}