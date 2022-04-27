using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Query
{
    public interface IQueryHandler<T> where T : IQuery
    {
        Task<IList<IResult>> Handle(T query);       
    }
}