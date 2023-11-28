using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.Entities;

namespace Vissoft.Infrastracture.Configuration
{
    public class ThematicConfiguration : IEntityTypeConfiguration<Thematic>
    {
        public void Configure(EntityTypeBuilder<Thematic> builder)
        {
            builder.ToTable("Thematic");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.course_id).IsRequired();
            builder.Property(x => x.lesson_id).IsRequired();
            builder.HasOne(x => x.Course).WithMany(x => x.Thematics).HasForeignKey(x => x.course_id);
            builder.HasOne(x => x.Lesson).WithMany(x => x.Thematics).HasForeignKey(x => x.lesson_id);
        }
    }
}
