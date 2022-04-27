using Application.Commond;
using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetPersonBetweenYear
{
    public class FindPersonBetweenYearCommandHandler :  IRequestHandler<FindPersonBetweenYearCommand, List<PersonDTO>>
    { 
        private readonly IRepository _repository;

        public FindPersonBetweenYearCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PersonDTO>> Handle(FindPersonBetweenYearCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _repository.Persons
                                               .Where(p => p.DateOfBirth.Year >= request.StartYear && p.DateOfBirth.Year <= request.EndYear)
                                               .Select(p => new PersonDTO
                                                            {
                                                                Id = p.Id,
                                                                FirstName = p.FirstName,
                                                                LastName = p.LastName,
                                                                DateOfBirth = p.DateOfBirth,
                                                            })
                                               .ToList());
        }
    }
}