using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_SIS.DAL.Factories
{
    public class DbContextSqLiteFactory : IDbContextFactory<SISDbContext>
    {
        private readonly bool _seedTestingData;
        private readonly DbContextOptionsBuilder<SISDbContext> _contextOptionsBuilder = new();

        public DbContextSqLiteFactory(string databaseName, bool seedTestingData = false)
        {
            _seedTestingData = seedTestingData;


            _contextOptionsBuilder.UseSqlite($"Data Source={databaseName}; Cache=Shared");
        }

        public SISDbContext CreateDbContext() => new(_contextOptionsBuilder.Options, _seedTestingData);
    }
}
