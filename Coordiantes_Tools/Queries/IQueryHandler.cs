using Coordiantes_Tools.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Queries
{
    internal interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        ICqsResult<TResult> Execute(TQuery query);
    }
}
