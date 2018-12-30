using Microsoft.EntityFrameworkCore;

namespace Event_Aggregator.Models
{
    public class Event_AggregatorContext : DbContext
    {
        public Event_AggregatorContext (DbContextOptions<Event_AggregatorContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
    }
}
