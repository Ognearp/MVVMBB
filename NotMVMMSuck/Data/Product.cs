namespace NotMVMMSuck.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            MaterialsProduct = new HashSet<MaterialsProduct>();
        }

        [Key]
        [StringLength(100)]
        public string name_product { get; set; }

        [Required]
        [StringLength(50)]
        public string articul { get; set; }

        public double min_cost { get; set; }

        [Required]
        [StringLength(100)]
        public string images { get; set; }

        [Required]
        [StringLength(50)]
        public string tip_product { get; set; }

        public int kol_for_proizv { get; set; }

        public int number_proizv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsProduct> MaterialsProduct { get; set; }
    }
}
