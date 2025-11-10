using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Entity = Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Queries.User
{
    public class GetUserByIdQuery : IQueryDefinition<Entity.User>
    {
        public Guid searchId { get; }

        public GetUserByIdQuery(Guid searchId)
        {
            this.searchId = searchId;
        }
    }
}
