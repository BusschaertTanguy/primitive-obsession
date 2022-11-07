using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

internal sealed class MyDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}