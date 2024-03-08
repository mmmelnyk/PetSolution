using Microsoft.EntityFrameworkCore;

namespace Pet.Api.Models
{
    public class DefaultDbContext(DbContextOptions<DefaultDbContext> options) : DbContext(options)
    {
    }
}