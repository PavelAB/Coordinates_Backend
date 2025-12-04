using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U = Coordinates_CQS_Domain.Entities.User;

namespace Coordinates_CQS_Domain.Entities.Rating
{
    public class Rating
    {

        Guid IdRating { get; set; }
        int Score { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        bool IsDeleted { get; set; }
        U.User CreatedBy { get; set; }
        U.User? UpdatedBy { get; set; }
        U.User? DeletedBy { get; set; }
        public Rating(
            Guid idRating, 
            int score, 
            U.User createdBy, 
            DateTime createdAt, 
            DateTime? updatedAt = null, 
            DateTime? deletedAt = null, 
            bool isDeleted = false, 
            U.User? updatedBy = null, 
            U.User? deletedBy = null
            )
        {
            IdRating = idRating;
            Score = score;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
            IsDeleted = isDeleted;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            DeletedBy = deletedBy;
        }
    }
}
