using Microsoft.EntityFrameworkCore;
using TechnobergServiceAPI.Models;

namespace TechnobergServiceAPI.Data
{
    public class TechnobergServiceContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<ActivationRequest> ActivationRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=technoberg_service;user=root;password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Device>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DeviceToken).IsRequired();
                entity.HasOne(d => d.User)
                .WithMany(p => p.Devices);
            });

            modelBuilder.Entity<ActivationRequest>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ActivationCode).IsRequired();
                entity.HasOne(e => e.User)
                .WithMany(d => d.ActivationRequests).IsRequired();
            });
        }



        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TechnobergServiceDB;Integrated Security=true;MultipleActiveResultSets=true;");
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

         }*/
    }
}
