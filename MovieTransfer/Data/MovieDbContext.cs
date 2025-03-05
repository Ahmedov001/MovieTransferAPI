using Microsoft.EntityFrameworkCore;
using MovieTransfer.Entities;

namespace MovieTransfer.Data
{
	public class MovieDbContext : DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options)
			: base(options)
		{
		}
        public DbSet<Movie> Movies{ get; set; }
    }
}
