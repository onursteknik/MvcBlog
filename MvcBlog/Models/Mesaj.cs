namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int ID { get; set; }

        public int? GondericiID { get; set; }

        public int? AliciID { get; set; }

        [StringLength(500)]
        public string Icerik { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? OkunduBilgisi { get; set; }

        public virtual Uye Uye { get; set; }

        public virtual Uye Uye1 { get; set; }
    }
}
