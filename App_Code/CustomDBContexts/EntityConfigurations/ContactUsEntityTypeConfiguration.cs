using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbracoBlogFinal1.App_Code.Models.CustomEntities.ContactUs;

namespace UmbracoBlogFinal1.App_Code.CustomDBContexts.EntityConfigurations
{
    public class ContactUsEntityTypeConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.FullName).HasMaxLength(256);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.Subject).IsRequired().HasMaxLength(512);
            builder.Property(x => x.Message).IsRequired();

            builder.ToTable("ContactUs");
        }
    }
}
