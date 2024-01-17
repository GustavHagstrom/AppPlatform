using AppPlatform.Server.Data;
using AppPlatform.Server.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;

namespace AppPlatform.Tests.Server;
public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
