using CKEditor_ASP.NETCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CKEditor_ASP.NETCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<UserArticle> UserArticles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId)
                    .HasName("PK__UserArticle");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ArticleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("article_id");

                entity.Property(e => e.ArticleTitle)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("article_title");

                entity.Property(e => e.DateTimeCreated)
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserArticles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserArticle_fk_User");
            });
        }
    }
}
