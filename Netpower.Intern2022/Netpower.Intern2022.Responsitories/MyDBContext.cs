using Microsoft.EntityFrameworkCore;
using Netpower.Intern2022.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Responsitories
{
    public class MyDBContext : DbContext
    {
        public DbSet<UserModel> dbo_User { get; set; }
        public DbSet<PositionModel> dbo_Position { get; set; }
        public DbSet<ProfileModel> dbo_Profile { get; set; }
        public DbSet<DepartmentModel> dbo_Department { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        public MyDBContext(){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EF_DATABASE;Integrated Security=True");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionModel>()
                .HasOne<DepartmentModel>(pos => pos.position_Department)
                .WithMany(depart => depart.PositionModels)
                .HasForeignKey(pos => pos.FK_Department);

            modelBuilder.Entity<ProfileModel>()
                .HasOne<PositionModel>(prf=>prf.prf_Role)
                .WithMany(pos => pos.profiles)
                .HasForeignKey(prf=>prf.FK_Role);

            modelBuilder.Entity<UserModel>()
                .HasOne<ProfileModel>(usr => usr.user_profile)
                .WithOne(prf => prf.profile_user)
                .HasForeignKey<ProfileModel>(prf=>prf.FK_User);
            
            modelBuilder.Entity<UserModel>()
           .HasAlternateKey(usr => usr.Mail);

            modelBuilder.Entity<PositionModel>()
                .HasAlternateKey(pos => pos.Name);

            modelBuilder.Entity<UserModel>()
                .HasAlternateKey(usr => usr.Mail);
            modelBuilder.Entity<UserModel>()
                .HasAlternateKey(usr => usr.UserName);

            modelBuilder.Entity<DepartmentModel>()
                .HasAlternateKey(depart => depart.Name);
        }
    }
}
