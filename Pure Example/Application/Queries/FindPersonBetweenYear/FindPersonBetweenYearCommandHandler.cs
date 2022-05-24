using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commond;
using Application.Interfaces;
using Application.Interfaces.Query;

namespace Application.Queries.FindPersonBetweenYear
{
    public class FindPersonBetweenYearCommandHandler : IQueryHandler<FindPersonBetweenYearCommand>
    {
        private readonly IRepository _repository;

        public FindPersonBetweenYearCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<IResult>> Handle(FindPersonBetweenYearCommand query)
        {
            return await Task.Run(() => _repository.Persons
                                   .Where(p => p.DateOfBirth.Year >= query.StartYear && p.DateOfBirth.Year <= query.EndYear)
                                   .Select(p => new PersonDTO
                                   {
                                       Id = p.Id,
                                       FirstName = p.FirstName,
                                       LastName = p.LastName,
                                       DateOfBirth = p.DateOfBirth,
                                   }).Cast<IResult>()
                                   .ToList());
        }
    }
}