using Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Command;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly IRepository _repository;

        public DeletePersonCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePersonCommand command)
        {
            var person = await Task.Run(() => _repository.Persons.SingleOrDefault(p => p.Id == command.Id));
            
            if (person == null)  throw new ArgumentNullException($"The person with id does not exist:{command.Id}");
            
            await Task.Run(() => _repository.Persons.Remove(person));
        }
    }
}