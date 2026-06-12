using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommonFiles
{
    public static class MigrationManager
    {
        public static void UpdateDatabase<IContext>(IApplicationBuilder app)
            where IContext : DbContext
        {
            Task.Run(() =>
            {
                using var serviceScope = app.ApplicationServices
                        .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();


                using var context = serviceScope.ServiceProvider
                .GetRequiredService<IContext>();

                // set the maximum time(in second) allowed for the database commands
                // it will be useful when the migration is taking more time to complete and we don't want to get timeout exception

                context.Database.SetCommandTimeout(1000);


                // Applies all pending migrations to the database
                // if in the database there is no migration is not exit
                // ef core will create the database and then apply the migration to it
                context.Database.Migrate();

            });

        }
    }
}
