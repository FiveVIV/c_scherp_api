using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace C_Scherp_Api.Models
{
    public class CScherpContext : IdentityDbContext<User>
    {
        public CScherpContext(DbContextOptions<CScherpContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
