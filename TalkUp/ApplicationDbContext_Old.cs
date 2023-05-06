using Microsoft.EntityFrameworkCore;

namespace TalkUp
{
    public class ApplicationDbContext_Old : DbContext
    {
        public ApplicationDbContext_Old(DbContextOptions<ApplicationDbContext_Old> options) : base(options)
        {
        }
    }
}
