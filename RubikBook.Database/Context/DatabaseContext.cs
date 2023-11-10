using Microsoft.EntityFrameworkCore;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Context;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(@"Data source=.;
                            Initial Catalog=RubikBookDb;
                            Integrated Security=SSPI");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Factor> Factors { get; set; }
    public DbSet<FactorDetail> FactorDetails { get; set; }
}
