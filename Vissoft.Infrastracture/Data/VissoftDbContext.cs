using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.Entities;
using Vissoft.Infrastracture.Configuration;

namespace Vissoft.Infrastracture.Data
{
    public class VissoftDbContext : DbContext
    {
        public VissoftDbContext(DbContextOptions<VissoftDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new ThematicConfiguration());
        }
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<Thematic> Thematics { get; set; } = null!;
    }
}
