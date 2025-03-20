using ICS_SIS.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_SIS.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SISDbContext>
    {
        private readonly DbContextSqLiteFactory _dbContextSqLiteFactory = new($"Data Source=ICS_SIS;Cache=Shared");

        public SISDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
    }
}
