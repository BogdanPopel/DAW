using DAW.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Data
{
    public class Context : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
       
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PublicEvent> PublicEvents{ get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<EventAttraction> EventAttractions { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Adress)
                .WithOne(a => a.Location);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.PublicEvents)
                .WithOne(pe => pe.Location);

            modelBuilder.Entity<EventAttraction>().HasKey(ea => new { ea.PublicEventId, ea.AttractionId });

            modelBuilder.Entity<EventAttraction>()
                .HasOne(ea => ea.PublicEvent)
                .WithMany(a => a.EventAttractions)
                .HasForeignKey(ea => ea.PublicEventId);

            modelBuilder.Entity<EventAttraction>()
                .HasOne(ea => ea.Attraction)
                .WithMany(a => a.EventAttractions)
                .HasForeignKey(ea => ea.AttractionId);
            /*
            modelBuilder.Entity<User>(u => {
                u.HasMany(u => u.UserRoles)
                    .WithOne(u => u.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(r => {
                r.HasMany(r => r.UserRoles)
                    .WithOne(r => r.Role)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            */
            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId } );

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);

                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });
            modelBuilder.Entity<UserRole>()
             .Navigation(ur => ur.Role)
             .UsePropertyAccessMode(PropertyAccessMode.Property);
           
            modelBuilder.Entity<UserRole>()
             .Navigation(ur => ur.User)
             .UsePropertyAccessMode(PropertyAccessMode.Property);


            base.OnModelCreating(modelBuilder);
            //Migration -> 20220902164739_Fix - Database_UserRoles
        }
    }
}
