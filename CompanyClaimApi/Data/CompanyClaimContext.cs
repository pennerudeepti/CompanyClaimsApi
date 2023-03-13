using Microsoft.EntityFrameworkCore;
using CompanyClaimApi.Models;

namespace CompanyClaimApi.Data
{
    public class CompanyClaimContext : DbContext
    {
        public CompanyClaimContext(DbContextOptions<CompanyClaimContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Company { get; set; } = null!;

        public DbSet<Claim> Claim { get; set; } = null!;

        public DbSet<CompanyClaimApi.Models.ClaimType> ClaimType { get; set; } = default!;
      
    }   
}
