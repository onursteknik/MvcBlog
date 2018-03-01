namespace MvcBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mvcblogDB : DbContext
    {
        public mvcblogDB()
            : base("name=mvcblogDB")
        {
        }

        public virtual DbSet<Bildirim> Bildirims { get; set; }
        public virtual DbSet<BildirimTur> BildirimTurs { get; set; }
        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Makale> Makales { get; set; }
        public virtual DbSet<Mesaj> Mesajs { get; set; }
        public virtual DbSet<Uye> Uyes { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BildirimTur>()
                .HasMany(e => e.Bildirims)
                .WithOptional(e => e.BildirimTur)
                .HasForeignKey(e => e.BildirimTuruID);

            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makales)
                .WithOptional(e => e.Kategori)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorums)
                .WithOptional(e => e.Makale)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Uye>()
                .Property(e => e.Sifre)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Bildirims)
                .WithRequired(e => e.Uye)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Mesajs)
                .WithOptional(e => e.Uye)
                .HasForeignKey(e => e.AliciID);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Mesajs1)
                .WithOptional(e => e.Uye1)
                .HasForeignKey(e => e.GondericiID);

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Yorums)
                .WithOptional(e => e.Uye)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Uye1)
                .WithMany(e => e.Uyes)
                .Map(m => m.ToTable("UyeArkadas").MapLeftKey("Uye1").MapRightKey("Uye2"));

            modelBuilder.Entity<Uye>()
                .HasMany(e => e.Uye11)
                .WithMany(e => e.Uyes1)
                .Map(m => m.ToTable("UyeEngelli").MapLeftKey("EngelliIUyeID").MapRightKey("UyeID"));
        }
    }
}
