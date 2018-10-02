namespace NewsService.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Data.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<NewsServiceDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
