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
    public class BedRoomRoomConfiguration : IEntityTypeConfiguration<BedRoomRoom>
    {
        public void Configure(EntityTypeBuilder<BedRoomRoom> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
