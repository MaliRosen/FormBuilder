using Microsoft.EntityFrameworkCore;
using ServerApp.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ServerApp.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FormTemplate> FormTemplates => Set<FormTemplate>();

        public DbSet<FormField> FormFields => Set<FormField>();

        public DbSet<ApprovalStep> ApprovalSteps => Set<ApprovalStep>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FormTemplate>()
                .HasMany(x => x.Fields)
                .WithOne(x => x.FormTemplate)
                .HasForeignKey(x => x.FormTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FormTemplate>()
                .HasMany(x => x.ApprovalSteps)
                .WithOne(x => x.FormTemplate)
                .HasForeignKey(x => x.FormTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
