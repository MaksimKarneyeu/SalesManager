using SalesManager.Data.Entities;
using System.Data.Entity;

namespace SalesManager.Data.Context
{
    public class SalesManagerContext : DbContext
    {
        public SalesManagerContext() : base("SalesManagerContext") 
        {
            
        }
        public DbSet<Document> Document { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>()
                .HasMany(s => s.Sales)
                .WithRequired(e => e.Document)
                .HasForeignKey(e => e.DocumentID);
        }
    }
}
