using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Runtime;

namespace DatabaseCore;

public class MicroloanDbContext : DbContext
{
    public DbSet<Money> Moneis { get; set; }

    public MicroloanDbContext(DbContextOptions o) : base(o) { }

}
