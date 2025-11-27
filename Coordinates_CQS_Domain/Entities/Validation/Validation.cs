using Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Validation
{
    public class Validation
    {

        Guid IdSpot { get; set; }
        Guid IdValidator { get; set; }
        bool IsValid { get; set; }
        DateTime ValidatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        public Validation(
            Guid idSpot, 
            Guid idValidator, 
            DateTime validatedAt, 
            DateTime? updatedAt = null,
            bool isValid = true) 
        {
            IdSpot = idSpot;
            IdValidator = idValidator;
            IsValid = isValid;
            ValidatedAt = validatedAt;
            UpdatedAt = updatedAt;
        }
    }
}
