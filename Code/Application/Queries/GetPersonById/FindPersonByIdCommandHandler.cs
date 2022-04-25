using Application.Commond;
using Application.Interfaces;
using Application.Interfaces.Query;
using System.Collections.Generic;
using System.Linq;

namespace Application.Queries
{
    public class FindPersonByIdCommandHandler: IQueryHandler<FindPersonByIdCommand>
    {
        private readonly IRepository _repository;

        public FindPersonByIdCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IList<IResult> Handle(FindPersonByIdCommand query)
        {
            var person = _repository.Persons.Where(p => p.Id.Equals(query.Id)).SingleOrDefault();
            if (person == null)
                return null;

            var results = new List<IResult>();

            var productDisplay = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,          
            };
            results.Add(productDisplay);

            return results;
        }
    }
}