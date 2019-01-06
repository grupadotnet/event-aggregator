using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Aggregator.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
