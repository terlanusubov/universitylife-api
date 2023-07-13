using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Entities;

namespace UniversityLifeApp.Infrastructure.Data.Configuration
{
    public class UserWishlistConfiguration : IEntityTypeConfiguration<UserWishlist>
    {
        public void Configure(EntityTypeBuilder<UserWishlist> builder)
        {
            builder.Property(x => x.BedRoomId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
