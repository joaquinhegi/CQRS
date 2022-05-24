using Application.Interfaces.Query;

namespace Application.Queries.FindPersonBetweenYear
{
    public class FindPersonBetweenYearCommand:IQuery
    {
        public int StartYear { get; init; }
        public int EndYear { get; init; }
    }
}