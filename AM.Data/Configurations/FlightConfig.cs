using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AM.Data.Configurations
{
    internal class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers) //Flight has many passengers
                .WithMany(p => p.Flights) //Passenger has many flights
                .UsingEntity(ass => ass.ToTable("PassFlight")); //Table intémédiaire

            builder.HasOne(f => f.MyPlane) //flight has one plane
                .WithMany(p => p.Flights) //plane has many flight
                .HasForeignKey(p => p.PlaneId) //foreign key 
                .OnDelete(DeleteBehavior.SetNull); //override method to set the foreign key to null when the principal is deleted

        }
    }
}
