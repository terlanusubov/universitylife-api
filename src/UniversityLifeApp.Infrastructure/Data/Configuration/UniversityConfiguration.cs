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
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
        }
    }
}
