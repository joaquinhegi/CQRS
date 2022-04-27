using Application.Commond;
using MediatR;

namespace Application.Queries
{
    public class FindPersonByIdCommand:IRequest<PersonDTO>
    {
        public int Id { get; set; }
    }
}