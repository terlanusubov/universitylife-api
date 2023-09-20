using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data.Configuration;

namespace UniversityLifeApp.Infrastructure.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BedRoomConfiguration());
            modelBuilder.ApplyConfiguration(new BedRoomPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new BedRoomRoomApplyConfiguartion());
            modelBuilder.ApplyConfiguration(new BedRoomRoomConfiguration());
            modelBuilder.ApplyConfiguration(new BedRoomRoomPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new BedRoomRoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserWishlistConfiguration());

            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.ApplyConfiguration(new OurServiceConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BedRoom> BedRooms { get; set; }
        public virtual DbSet<BedRoomPhoto> BedRoomPhotos { get; set; }
        public virtual DbSet<BedRoomRoom> BedRoomRooms { get; set; }
        public virtual DbSet<BedRoomRoomApply> BedRoomRoomApplies { get; set; }
        public virtual DbSet<BedRoomRoomPhoto> BedRoomRoomPhotos { get; set; }
        public virtual DbSet<BedRoomRoomType> BedRoomRoomTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserWishlist> UserWishlists { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<OurService> OurServices { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

    }
}
