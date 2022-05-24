using Application.Interfaces;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommand:ICommand
    {
        public int Id { get; init; }
    }
}