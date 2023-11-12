using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    public class EventSection
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }

        public List<SectionSeat> SectionSeats { get; set; } = new List<SectionSeat>();

        public EventSectionPrice? EventSectionPrice { get; set; }
    }
}
