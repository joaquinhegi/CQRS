using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task Handle(T command);
    }
}