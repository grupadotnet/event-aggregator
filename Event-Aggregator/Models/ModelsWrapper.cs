using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Aggregator.Models
{
    public class ModelsWrapper
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
