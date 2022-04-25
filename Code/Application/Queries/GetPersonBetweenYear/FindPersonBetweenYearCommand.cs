using Application.Interfaces.Query;

namespace Application.Queries.GetPersonBetweenYear
{
    public class FindPersonBetweenYearCommand:IQuery
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}