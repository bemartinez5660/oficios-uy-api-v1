using Microsoft.EntityFrameworkCore;
using OficiosUy.Api.Models.Entities;

namespace OficiosUy.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
}