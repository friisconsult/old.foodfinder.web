using Microsoft.EntityFrameworkCore;

namespace FoodFinder.Web.Model
{
    public sealed class TemplateContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}