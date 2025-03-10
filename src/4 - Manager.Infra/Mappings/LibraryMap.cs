using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class LibraryMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
           builder.ToTable("Library");

           builder.HasKey(x => x.Id); 

           builder.Property(x => x.Id)
                    .UseIdentityColumn()
                    .HasColumnType("BIGINT");

            builder.Property(x => x.BookName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nameBk")
                    .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.BookCodeSerial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("codeSerial")
                    .HasColumnType("BIGINT");

            builder.Property(x => x.BookExists)
                    .IsRequired()
                    .HasMaxLength(180)
                    .HasColumnName("bkExists")
                    .HasColumnType("BIT");                       
        }
    }
}