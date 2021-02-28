using Contact.Mgmt.DataModel.Enums;
using Contact.Mgmt.DataModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact.Mgmt.API.Data.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<ContactInfo> Contacts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ContactInfo>().ToTable("Contacts");
            builder.Entity<ContactInfo>().HasKey(key => key.Id);
            builder.Entity<ContactInfo>().Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ContactInfo>().Property(prop => prop.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<ContactInfo>().Property(prop => prop.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<ContactInfo>().Property(prop => prop.Email).IsRequired().HasMaxLength(30);
            builder.Entity<ContactInfo>().Property(prop => prop.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Entity<ContactInfo>().Property(prop => prop.Status).IsRequired();

            builder.Entity<ContactInfo>().HasData
            (
                new ContactInfo { Id = 100, FirstName = "Bruce", LastName = "Wayne", Email = "bruce.wayne@batman.com", PhoneNumber = "9999955555", Status = EContactStatus.Active },
                new ContactInfo { Id = 101, FirstName = "Thor", LastName = "Odinson", Email = "thor.odinson@avengers,com", PhoneNumber = "9999944444", Status = EContactStatus.Inactive }
            );
        }
    }
}
