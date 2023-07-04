using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public int UserStatusId { get; set; }

        //User role
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        //User wishlist
        public ICollection<UserWishlist> UserWishLists { get; set; }
    }
}
