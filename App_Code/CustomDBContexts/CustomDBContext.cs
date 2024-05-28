using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using UmbracoBlogFinal1.App_Code.CustomDBContexts.EntityConfigurations;
using UmbracoBlogFinal1.App_Code.Models.CustomEntities.ContactUs;

namespace UmbracoBlogFinal1.App_Code.CustomDBContexts
{
    public class CustomDBContext:DbContext
    {
        public CustomDBContext(DbContextOptions<CustomDBContext> options): base(options)
        {
            
        }
        public required DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ContactUsEntityTypeConfiguration().Configure(modelBuilder.Entity<ContactUs>());
        }
    }
}
