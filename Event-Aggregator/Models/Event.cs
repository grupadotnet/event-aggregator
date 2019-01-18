using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event_Aggregator.Models
{
    public class Event
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        [StringLength(30)]
        [Required]
        public string ShortTitle { get; set; }

        [StringLength(60)]
        public string LongerTitle { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Localization { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }
    }
}
