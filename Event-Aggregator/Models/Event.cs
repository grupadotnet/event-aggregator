using System;

namespace Event_Aggregator.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Category Category { get; set; }
        public string Hash { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
    }
}
