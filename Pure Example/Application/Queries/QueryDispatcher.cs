using Application.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _service;

        public QueryDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public async Task<IList<IResult>> Send<T>(T query) where T : IQuery
        {
            var handler = _service.GetService(typeof(IQueryHandler<T>));

            if (handler == null)
                throw new Exception($"Query doesn't have any handler {query.GetType().Name}");


            return await ((IQueryHandler<T>)handler).Handle(query);          
        }
    }
}