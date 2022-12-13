using Microsoft.EntityFrameworkCore;

namespace ApiChallenger.Context
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options) { }

        public DbSet<ApiChallenger.Models.Task> Tasks { get; set; }
    }
}