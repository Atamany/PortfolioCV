using Microsoft.EntityFrameworkCore;
using PortfolioCV.DAL.Entities;

namespace PortfolioCV.DAL.Context
{
    public class PortfolioCVContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseSqlServer("Server=YIGITATAMANPC;initial Catalog=PortfolioCVDb;integrated Security=True;TrustServerCertificate=True;");
    }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Deneyim> Deneyims { get; set; }
        public DbSet<Egitim> Egitims { get; set; }
        public DbSet<Gonullu> Gonullus { get; set; }
        public DbSet<Hakkinda> Hakkindas { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Proje> Projes { get; set; }
        public DbSet<Referans> Referanss { get; set; }
        public DbSet<Sertifika> Sertifikas { get; set; }
        public DbSet<Sosyal> Sosyals { get; set; }
        public DbSet<Dizi> Dizis { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Tiyatro> Tiyatros { get; set; }
        public DbSet<YouTube> YouTubes { get; set; }
}
}
