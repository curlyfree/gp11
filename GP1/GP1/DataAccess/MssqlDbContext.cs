using Microsoft.EntityFrameworkCore;
using Graduation.Project.Api.DataAccess.Entities;

namespace Graduation.Project.Api.DataAccess
{
    public class MssqlDbContext : DbContext, IDBContext
    {
        private readonly IConfiguration _config;
        public MssqlDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<SehirlerEntity> Sehirler { get; set; }
        public DbSet<GezilecekYerlerEntity> Yerler { get; set; }
        public DbSet<YerBilgileriEntity> YerBilgileri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            #region Şehirler
            modelBuilder.Entity<SehirlerEntity>().ToTable("Şehirler");
            modelBuilder.Entity<SehirlerEntity>().HasKey(a => a.ID);
            modelBuilder.Entity<SehirlerEntity>().Property(a => a.ID).HasColumnName("ID");
            modelBuilder.Entity<SehirlerEntity>().Property(a => a.Şehirler).HasColumnName("Şehirler");
            #endregion

            #region Gezilecek Yerler
            modelBuilder.Entity<GezilecekYerlerEntity>().ToTable("Gezilecek_Yerler");
            modelBuilder.Entity<GezilecekYerlerEntity>().HasKey(a => a.ID);
            modelBuilder.Entity<GezilecekYerlerEntity>().Property(a => a.ID).HasColumnName("ID");
            modelBuilder.Entity<GezilecekYerlerEntity>().Property(a => a.Şehir_Id).HasColumnName("Şehir_Id");
            modelBuilder.Entity<GezilecekYerlerEntity>().Property(a => a.Gezilecek_Yerler).HasColumnName("Gezilecek_Yerler");
            #endregion

            #region Yer Bilgileri
            modelBuilder.Entity<YerBilgileriEntity>().ToTable("Yer_Bilgileri");
            modelBuilder.Entity<YerBilgileriEntity>().HasNoKey();
            modelBuilder.Entity<YerBilgileriEntity>().Property(a => a.yer_bilgisi).HasColumnName("yer_bilgisi");
            modelBuilder.Entity<YerBilgileriEntity>().Property(a => a.yer_id).HasColumnName("yer_id");
            #endregion
        }

    }

}