using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoWebMVC.Models
{
    [Table("Details")]
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        public int IdCommande { get; set; }
        [ForeignKey("IdCommande")]
        public virtual Commande Commande { get; set; }

        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }

        public int Quantite { get; set; }
    }
}