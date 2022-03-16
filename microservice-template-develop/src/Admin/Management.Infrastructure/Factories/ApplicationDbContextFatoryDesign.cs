#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

#endregion

namespace Management.Infrastructure.Factories
{
    public class ApplicationDbContextFatoryDesign : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        #region IDesignTimeDbContextFactory<ApplicationDbContext> Members

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseSqlServer("Server=192.168.1.10;Initial Catalog=ReportDb;User Id=avinams;Password=ABcd1234!@#$");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
.UseSqlServer("Server=192.168.222.153;Initial Catalog=TrainingDb;User Id=lab_etc_clsmicro;Password=clsmc40@123456!");
            return new ApplicationDbContext(optionsBuilder.Options, null);
        }

        #endregion
    }
}