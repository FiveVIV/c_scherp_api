using Microsoft.EntityFrameworkCore;

namespace C_Scherp_Api.Models
{
    public class CScherpContext : DbContext
    {
        public CScherpContext(DbContextOptions<CScherpContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
