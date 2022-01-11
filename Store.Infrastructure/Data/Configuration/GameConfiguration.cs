using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Entities;

namespace Store.Infrastructure.Data.Configuration
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .IsRequired();

            builder
                .Property(p => p.Discont)
                .IsRequired();

            builder
                .Property(p => p.Approved)
                .IsRequired();

            builder
                .Property(p => p.Developer)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
