using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.EntityType
{
    public class EntityType
    {

        Guid IdEntityType { get; set; }
        string Name {  get; set; }
        public EntityType(Guid idEntityType, string name)
        {
            IdEntityType = idEntityType;
            Name = name;
        }
    }
}
