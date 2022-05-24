using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commond;
using Application.Interfaces;
using Application.Interfaces.Query;

namespace Application.Queries.FindPersonById
{
    public class FindPersonByIdCommandHandler: IQueryHandler<FindPersonByIdCommand>
    {
        private readonly IRepository _repository;

        public FindPersonByIdCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<IResult>> Handle(FindPersonByIdCommand query)
        {
            var person = await Task.Run(() => _repository.Persons.SingleOrDefault(p => p.Id.Equals(query.Id)));
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