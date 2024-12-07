using Microsoft.EntityFrameworkCore;
namespace DBUpdate.Models
{
    public class C500HemisContext : DbContext
    {
        public C500HemisContext(DbContextOptions<C500HemisContext> options) : base(options) { }

        //DbSet<dmQuocTich>? dmQuocTiches { get; set; } = default!;
        public DbSet<table1>? table1s { get; set; }
        public DbSet<table2>? table2s { get; set; }
        public DbSet<table3>? table3s { get; set; }
        public DbSet<Nhap>? nhaps { get; set; }
        public DbSet<data>? datas { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<dmBacLuong>(e =>
        //    {
        //        e.HasOne(e => e.Khoinganh)
        //        .WithMany(d => d.dmBacLuongs)
        //        .HasForeignKey(e => e.Id1)
        //        .HasConstraintName("FK_dmKhoiNganhLinhVucDaoTao_dmKhoiNganh");
        //        e.HasOne(e => e.linhvuc)
        //        .WithMany(d => d.dmBacLuongs)
        //        .HasForeignKey(e => e.Id2)
        //        .HasConstraintName("FK_dmKhoiNganhLinhVucDaoTao_dmLinhVucDaoTao");
        //    });
        //}
    }
}
