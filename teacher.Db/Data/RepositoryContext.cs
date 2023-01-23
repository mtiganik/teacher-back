using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Models.Models;

namespace teacher.Db.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostData());
            modelBuilder.ApplyConfiguration(new TeachingTakesPlaceData());
            modelBuilder.ApplyConfiguration(new SubjectsData());
        }

        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<TeachingTakesPlace> TeachingTakesPlace {get;set;} = default!;
        public DbSet<Subject> Subject { get; set; } = default!;

    }
}
