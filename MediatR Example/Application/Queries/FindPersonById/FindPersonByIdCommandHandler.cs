using Application.Commond;
using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class FindPersonByIdCommandHandler : IRequestHandler<FindPersonByIdCommand, PersonDTO>
    {
        private readonly IRepository _repository;

        public FindPersonByIdCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonDTO> Handle(FindPersonByIdCommand request, CancellationToken cancellationToken)
        {
            var person = await Task.Run(() => _repository.Persons.SingleOrDefault(p => p.Id.Equals(request.Id)));
           
            if (person == null)
                return null;

            var productDisplay = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
            };

            return productDisplay; 
        }
    }
}