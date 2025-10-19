using Coordiantes_Tools.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Queries
{
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        ValueTask<ICqsResult<TResult>> ExecuteAsync(TQuery query);
    }
}
