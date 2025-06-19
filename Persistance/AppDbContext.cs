using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
}
