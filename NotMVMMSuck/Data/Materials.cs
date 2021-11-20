namespace NotMVMMSuck.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            MaterialsProduct = new HashSet<MaterialsProduct>();
        }

        [Key]
        [StringLength(100)]
        public string name_materials { get; set; }

        [Required]
        [StringLength(255)]
        public string tip_materials { get; set; }

        public double kol_vo_upakovke { get; set; }

        [Required]
        [StringLength(255)]
        public string edinicha_izm { get; set; }

        public double kol_vo_sklad { get; set; }

        public double Min_voz_ostatok { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialsProduct> MaterialsProduct { get; set; }
    }
}
