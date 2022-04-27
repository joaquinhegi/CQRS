using MediatR;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}