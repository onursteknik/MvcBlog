namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bildirim")]
    public partial class Bildirim
    {
        public int ID { get; set; }

        public int UyeID { get; set; }

        public int? BildirimTuruID { get; set; }

        [StringLength(200)]
        public string BildirimIcerik { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual BildirimTur BildirimTur { get; set; }

        public virtual Uye Uye { get; set; }
    }
}
