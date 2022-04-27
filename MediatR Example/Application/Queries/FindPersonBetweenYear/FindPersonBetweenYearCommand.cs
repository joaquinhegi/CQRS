using Application.Commond;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.GetPersonBetweenYear
{
    public class FindPersonBetweenYearCommand :IRequest<List<PersonDTO>>
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}