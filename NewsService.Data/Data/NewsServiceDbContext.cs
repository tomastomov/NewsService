namespace NewsService.Data.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NewsServiceDbContext : DbContext
    {
        public NewsServiceDbContext(DbContextOptions<NewsServiceDbContext> options) : base(options) { }

        public DbSet<New> News { get; set; } 
    }
}
