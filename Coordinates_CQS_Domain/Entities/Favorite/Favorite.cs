using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Favorite
{
    public class Favorite
    {
        Guid IdSpot { get; set; }
        Guid IdUser { get; set; }
        bool IsFavorite { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        public Favorite(
            Guid idSpot,
            Guid idUser,
            DateTime createdAt,
            DateTime? updatedAt = null,
            bool isFavorite = true)
        {
            IdSpot = idSpot;
            IdUser = idUser;
            IsFavorite = isFavorite;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
