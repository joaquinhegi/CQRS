using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, int>
    {
        public IRepository _repository;

        public DeletePersonCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await Task.Run(() => _repository.Persons.Where(p => p.Id == request.Id).SingleOrDefault());
            
            if (person == null) throw new ArgumentNullException($"The person with id does not exist:{request.Id}");
         
            await Task.Run(() => _repository.Persons.Remove(person));

            return request.Id;
        }
    }
}