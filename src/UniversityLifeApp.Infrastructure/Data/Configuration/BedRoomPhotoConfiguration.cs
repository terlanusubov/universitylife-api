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
    public class BedRoomPhotoConfiguration : IEntityTypeConfiguration<BedRoomPhoto>
    {
        public void Configure(EntityTypeBuilder<BedRoomPhoto> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsMain).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.BedroomId).IsRequired();
        }
    }
}
