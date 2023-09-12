using BidConReport.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BidconReport.Tests.Server;
public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
