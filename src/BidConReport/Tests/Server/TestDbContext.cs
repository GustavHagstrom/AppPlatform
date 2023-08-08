using BidConReport.Server.Data;
using BidConReport.Shared.Entities.ReportTemplate;
using Microsoft.EntityFrameworkCore;

namespace BidconReport.Tests.Server;
public class TestDbContext : ApplicationDbContext
{
    public TestDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<FontProperties> FontProperties { get; set; }
}
