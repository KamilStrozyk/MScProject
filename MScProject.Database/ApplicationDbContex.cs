using System;
using Microsoft.EntityFrameworkCore;
using MScProject.Database.Models;

namespace MScProject.Database
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskPhoto>()
                .HasKey(x => x.PhotoId);
        }
        
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<TaskPhoto> TaskPhotos { get; set; }
    }
}