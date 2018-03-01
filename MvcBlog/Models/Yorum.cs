namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int YorumID { get; set; }


        [StringLength(500, ErrorMessage = "Yorum içeriðinin karakter sayýsý 500'ü geçemez.")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Icerik { get; set; }

        public int? UyeID { get; set; }

        public int? MakaleID { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual Makale Makale { get; set; }

        public virtual Uye Uye { get; set; }
    }
}
