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
    public class BedRoomRoomApplyConfiguartion : IEntityTypeConfiguration<BedRoomRoomApply>
    {
        public void Configure(EntityTypeBuilder<BedRoomRoomApply> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BedRoomRoomId).IsRequired();
        }
    }
}
