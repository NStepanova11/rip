using Microsoft.EntityFrameworkCore;

namespace MyRipBlog.Models
{
    public class MyRipBlogContext : DbContext
    {
        public MyRipBlogContext(DbContextOptions<MyRipBlogContext> options)
            :base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagSet> TagSets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        /*
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagSet> TagSets { get; set; }

        public MyRipBlogContext(DbContextOptions<MyRipBlogContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        */
    }
}
