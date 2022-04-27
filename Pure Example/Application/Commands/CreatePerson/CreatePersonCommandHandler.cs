using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreatePersonCommandHandler:ICommandHandler<CreatePersonCommand>
    {
        private readonly IRepository _repository;

        public CreatePersonCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePersonCommand command)
        {
            var person = new Person
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth
            };

            await Task.Run(() => _repository.Persons.Add(person));
        }
    }
}