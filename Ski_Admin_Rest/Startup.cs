using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ski_Admin_Rest
{
    // ConfigureServices-Methode in Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AuftragsDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // ...
    }

}
