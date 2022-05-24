using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Command;
using Domain.Entities;

namespace Application.Commands.CreatePerson
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