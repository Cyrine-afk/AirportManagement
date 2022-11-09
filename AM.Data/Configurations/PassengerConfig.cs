using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    internal class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.MyFullName) 
                .Property(f => f.FirstName)
                .HasColumnName("Name")
                .HasMaxLength(25);

            builder.OwnsOne(p => p.MyFullName)
                .Property(f => f.LastName)
                .IsRequired();
        }
    }
}
