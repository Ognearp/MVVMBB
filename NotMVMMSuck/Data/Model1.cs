using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NotMVMMSuck.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<MaterialsProduct> MaterialsProduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>()
                .Property(e => e.name_materials)
                .IsUnicode(false);

            modelBuilder.Entity<Materials>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Materials>()
                .HasMany(e => e.MaterialsProduct)
                .WithRequired(e => e.Materials)
                .HasForeignKey(e => e.name_material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name_product)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.articul)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.tip_product)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MaterialsProduct)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialsProduct>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialsProduct>()
                .Property(e => e.name_material)
                .IsUnicode(false);
        }
    }
}
