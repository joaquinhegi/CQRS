using Application.Interfaces.Query;

namespace Application.Queries
{
    public class FindPersonByIdCommand:IQuery
    {
        public int Id { get; set; }
    }
}