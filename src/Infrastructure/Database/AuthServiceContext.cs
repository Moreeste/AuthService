using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AuthServiceContext : DbContext
    {
        public AuthServiceContext(DbContextOptions<AuthServiceContext> options) : base(options)
        {

        }
    }
}
