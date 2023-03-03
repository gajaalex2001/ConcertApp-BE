using ConcertApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConcertApp.Migrations
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ConcertAppContext>
    {
        private const string LocalSql= "Data Source=DESKTOP-S145S69;Initial Catalog=ConcertApp;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=true";

        private static readonly string MigrationAssemblyName = typeof(DesignTimeContextFactory).Assembly.GetName().Name;

        public ConcertAppContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConcertAppContext>()
                .UseSqlServer(args.FirstOrDefault() ?? LocalSql,
                op => op.MigrationsAssembly(MigrationAssemblyName));
            return new ConcertAppContext(builder.Options);
        }
    }
}
