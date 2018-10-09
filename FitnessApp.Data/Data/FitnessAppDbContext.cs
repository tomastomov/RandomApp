namespace FitnessApp.Data.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FitnessAppDbContext : IdentityDbContext<User>
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryArticle> CategoryArticles { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodDiary> FoodDiaries { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Replies { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CategoryArticle>()
                .HasKey(ca => new { ca.ArticleId, ca.CategoryId });

            builder.Entity<CategoryArticle>()
                .HasOne(c => c.Category)
                .WithMany(a => a.Articles)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<CategoryArticle>()
                .HasOne(a => a.Article)
                .WithMany(c => c.Categories)
                .HasForeignKey(a => a.ArticleId);

        }
    }
}
