using Microsoft.EntityFrameworkCore;
using Netpower.Training.Intern2022.API.Entities;

namespace Netpower.Training.Intern2022.API.Repositories.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(AppSetting.AppSetting.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>()
                .HasIndex(depart => new
                {
                    depart.Name,
                    //depart.FK_Position
                })
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(usr => new
                {
                    usr.UserName,
                    usr.Email
                })
                .IsUnique();

            builder.Entity<Position>()
                .HasIndex(pos => pos.Name)
                .IsUnique();

            //builder.Entity<Profile>()
            //    .HasIndex(prf => prf.FK_User)
            //    .IsUnique();
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<User> User { get; set; }
    }
}
