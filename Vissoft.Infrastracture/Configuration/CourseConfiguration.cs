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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.grade_id).IsRequired();
            builder.Property(x => x.createdAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasOne(x => x.Grade).WithMany(x => x.Courses).HasForeignKey(x => x.grade_id);
        }
    }
}
