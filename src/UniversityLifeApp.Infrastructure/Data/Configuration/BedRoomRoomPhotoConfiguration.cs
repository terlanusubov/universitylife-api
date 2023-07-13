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
    public class BedRoomRoomPhotoConfiguration : IEntityTypeConfiguration<BedRoomRoomPhoto>
    {
        public void Configure(EntityTypeBuilder<BedRoomRoomPhoto> builder)
        {
            builder.Property(x => x.IsMain).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.BedRoomRoomId).IsRequired();
        }
    }
}
