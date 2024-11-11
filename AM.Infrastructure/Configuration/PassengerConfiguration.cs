using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasDiscriminator<String>("IsTraveller")
                .HasValue<Traveller>("1")
                .HasValue<Passenger>("0")
                .HasValue<Staff>("2");
            builder.OwnsOne(p => p.FullName, fn =>
            {
                fn.Property(fn => fn.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                fn.Property(fn => fn.LastName).HasColumnName("PassLastName").IsRequired();
            });
        }
    }
}
