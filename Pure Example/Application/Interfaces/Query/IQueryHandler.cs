using System.Collections.Generic;

namespace Application.Interfaces.Query
{
    public interface IQueryHandler<T> where T : IQuery
    {        
        IList<IResult> Handle(T query);       
    }
}