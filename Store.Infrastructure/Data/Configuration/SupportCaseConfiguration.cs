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
    class SupportCaseConfiguration : IEntityTypeConfiguration<SupportCase>
    {
        public void Configure(EntityTypeBuilder<SupportCase> builder)
        {
            builder
                .HasKey(p => new { p.UserId, p.SupportId, p.MessageId });
        }
    }
}
