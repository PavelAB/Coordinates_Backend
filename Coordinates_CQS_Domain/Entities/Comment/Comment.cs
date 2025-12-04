using U = Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Comment
{
    public class Comment
    {

        Guid IdComment { get; set; }
        string Body { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        bool IsDeleted { get; set; }
        U.User CreatedBy { get; set; }
        U.User? UpdatedBy { get; set; }
        U.User? DeletedBy { get; set; }
        public Comment(
            Guid idComment, 
            string body, 
            DateTime createdAt, 
            U.User createdBy, 
            bool isDeleted = false, 
            DateTime? updatedAt = null, 
            DateTime? deletedAt = null, 
            U.User? updatedBy = null, 
            U.User? deletedBy = null)
        {
            IdComment = idComment;
            Body = body;
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
