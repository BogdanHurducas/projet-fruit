namespace DemoWebMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM")
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Categorie)
                .HasForeignKey(e => e.IdCategorie);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Prix)
                .HasPrecision(19, 4);
        }
    }
}
