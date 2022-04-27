using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreatePersonCommandHandler:IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IRepository _repository;

        public CreatePersonCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            await Task.Run(() => _repository.Persons.Add(person));

            return request.Id;
        }
    }
}