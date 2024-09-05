using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.MapFluentApi
{
    public class TransportationMap : IEntityTypeConfiguration<Transportation>
    {
        public void Configure(EntityTypeBuilder<Transportation> builder)
        {
            builder.ToTable("Transportation");
            builder.HasKey(p => p.TransportationId);
            builder.Property(p => p.InitialPrise).IsRequired();
            builder.Property(p => p.PrisePerKg).IsRequired();
            builder.Property(p => p.TransportationCompany).HasMaxLength(200).IsRequired();

            builder.HasData(new List<Transportation>()
            {
                new Transportation() {TransportationId = 1 , InitialPrise = 40000,PrisePerKg = 10000,TransportationCompany = "تیپاکس"},
                new Transportation() {TransportationId = 2 , InitialPrise = 35000,PrisePerKg = 10000,TransportationCompany = "پست ویژه"},
                new Transportation() {TransportationId = 3 , InitialPrise = 50000,PrisePerKg = 12000, TransportationCompany = "پست ویژه"},
                new Transportation() {TransportationId = 4 , InitialPrise = 30000,PrisePerKg = 9000 ,TransportationCompany = "پست سفارشی"}
            });

            //Many To One Relation Between TransportationTable And OrderTable
            builder.HasMany(c=>c.Orders).WithOne(o=>o.Transportation).HasForeignKey(o=>o.TransportationId);
        }
    }
}
