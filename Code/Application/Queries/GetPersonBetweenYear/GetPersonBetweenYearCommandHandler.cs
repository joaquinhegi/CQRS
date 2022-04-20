﻿using Application.Commond;
using Application.Interfaces;
using Application.Interfaces.Query;
using System.Collections.Generic;
using System.Linq;

namespace Application.Queries.GetPersonBetweenYear
{
    public class GetPersonBetweenYearCommandHandler : IQueryHandler<GetPersonBetweenYearCommand>
    {
        private readonly IRepository _repository;

        public GetPersonBetweenYearCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IList<IResult> Handle(GetPersonBetweenYearCommand query)
        {
            var persons = _repository.Persons.Where(p => p.DateOfBirth.Year >= query.StartYear && p.DateOfBirth.Year <= query.EndYear);
            if (persons == null)
                return null;

            var results = new List<IResult>();
            
            foreach (var person in persons)
            {
                var productDisplay = new PersonDTO
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    DateOfBirth = person.DateOfBirth,
                };
                results.Add(productDisplay);
            }
          
            return results;
        }
    }
}