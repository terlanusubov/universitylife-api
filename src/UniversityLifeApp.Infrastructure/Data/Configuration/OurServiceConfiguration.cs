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
    public class OurServiceConfiguration : IEntityTypeConfiguration<OurService>
    {
        public void Configure(EntityTypeBuilder<OurService> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
