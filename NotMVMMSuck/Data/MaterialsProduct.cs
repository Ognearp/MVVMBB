namespace NotMVMMSuck.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialsProduct")]
    public partial class MaterialsProduct
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Product { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string name_material { get; set; }

        public double? neobxodimoe_kol_vo_materiala { get; set; }

        public virtual Materials Materials { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
