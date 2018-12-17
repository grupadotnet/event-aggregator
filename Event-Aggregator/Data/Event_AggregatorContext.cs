using Microsoft.EntityFrameworkCore;

namespace Event_Aggregator.Models
{
    public class Event_AggregatorContext : DbContext
    {
        public Event_AggregatorContext (DbContextOptions<Event_AggregatorContext> options)
            : base(options)
        {
        }

        public DbSet<Event_Aggregator.Models.Event> Event { get; set; }
    }
}
