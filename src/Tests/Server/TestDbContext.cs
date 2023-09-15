using Server.Data;
using Server.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;

namespace Tests.Server;
public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
