using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddPersonCommandHandler:ICommandHandler<AddPersonCommand>
    {
        private readonly IRepository _repository;

        public AddPersonCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddPersonCommand command)
        {
            var person = new Person
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth
            };

            _repository.Persons.Add(person);

            await Task.Run(() => { });
        }
    }
}