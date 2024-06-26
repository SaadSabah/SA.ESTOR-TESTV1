using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SA.ESTOR_TESTV1.Models;


namespace SA.ESTOR_TESTV1.Services
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<HandMProduct> HandMProducts { get; set; }
	}
}
