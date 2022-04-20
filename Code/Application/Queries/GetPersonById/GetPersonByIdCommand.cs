using Application.Interfaces.Query;

namespace Application.Queries
{
    public class GetPersonByIdCommand:IQuery
    {
        public int Id { get; set; }
    }
}