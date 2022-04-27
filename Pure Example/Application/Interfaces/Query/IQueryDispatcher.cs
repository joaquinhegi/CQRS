using System.Collections.Generic;

namespace Application.Interfaces.Query
{
    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
    }
}