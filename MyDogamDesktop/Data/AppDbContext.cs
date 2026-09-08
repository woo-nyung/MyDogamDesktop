using Microsoft.EntityFrameworkCore;
using MyDogamDesktop.Models;

namespace MyDogamDesktop.Data
{
    public class AppDbContext : DbContext // 상속
    {
        // DbSet 프로퍼티를 통해 Collection, Items 테이블 설정
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // SQLite 사용 & 파일 경로와 이름 설정
        {
            string dbPath = Path.Combine(AppContext.BaseDirectory, "mydogam.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // 테이블 구조 및 관계 설정
        {
            modelBuilder.Entity<CollectionItem>()
                .HasOne(item => item.Collection) // 한개의 Collection을 가짐
                .WithMany(collection => collection.Items) // 여러개의 CollectionItem을 가짐
                .HasForeignKey(item => item.CollectionId); // 외래키는 CollectionId
        }
    }
}
