using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Enums;

namespace UniversityLifeApp.Domain.Entities
{
    public class User : BaseEntity
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

        //Bedroomroom apply
        public ICollection<BedRoomRoomApply> BedRoomRoomApplies { get; set; }

        public void AddPassword(string password)
        {
            Guid guid = Guid.NewGuid();

            using (SHA256 sha256 = SHA256.Create())
            {
                var salt = sha256.ComputeHash(Encoding.UTF8.GetBytes(guid.ToString()));

                using (HMACSHA256 hmacsha256 = new HMACSHA256(salt))
                {
                    var buffer = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                    Salt = salt;
                    Password = buffer;
                }
            }
        }

        public bool CheckPassword(string password)
        {
            using (HMACSHA256 hmacSha256 = new HMACSHA256(Salt))
            {
                var buffer = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return buffer.SequenceEqual(Password);
            }
        }
    }
}
