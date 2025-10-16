using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.User
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NickName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string? Avatar { get; set; }
        public string? Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
