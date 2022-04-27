using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface IQueryDispatcher
    {
        Task<IList<IResult>> Send<T>(T query) where T : IQuery;
    }
}