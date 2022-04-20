using Application.Commond;
using Application.Interfaces;
using Application.Interfaces.Query;
using System.Collections.Generic;
using System.Linq;

namespace Application.Queries
{
    public class GetPersonByIdCommandHandler: IQueryHandler<GetPersonByIdCommand>
    {
        private readonly IRepository _repository;

        public GetPersonByIdCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IList<IResult> Handle(GetPersonByIdCommand query)
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