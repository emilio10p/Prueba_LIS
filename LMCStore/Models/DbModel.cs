namespace LMCStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.Area_name)
                .IsFixedLength();

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Area1)
                .HasForeignKey(e => e.AREA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PRODUCT_NAME)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.PRODUCT_REFERENCE)
                .IsFixedLength();
        }
    }
}
