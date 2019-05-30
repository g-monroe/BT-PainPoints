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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
