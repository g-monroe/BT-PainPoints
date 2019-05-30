using BTSuggestions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.DataAccessHandlers
{
    public class BTSuggestionContext : DbContext
    {
        public BTSuggestionContext() : base()
        {

        }
        public BTSuggestionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PainPointEntity> PainPoints { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<PainPointTypeEntity> PainPointTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PainPointTypeEntity>()
                .HasOne<PainPointEntity>(sc => sc.PainPoint)
                .WithMany(s => s.TypeEnties)
                .HasForeignKey(sa => sa.PainPointId);

            modelBuilder.Entity<PainPointTypeEntity>()
                .HasOne<TypeEntity>(sa => sa.Type)
                .WithMany(a => a.TypeEntities)
                .HasForeignKey(sa => sa.TypeId);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
