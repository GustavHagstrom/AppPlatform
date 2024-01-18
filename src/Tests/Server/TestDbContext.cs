using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;

namespace AppPlatform.Tests.Server;
public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
