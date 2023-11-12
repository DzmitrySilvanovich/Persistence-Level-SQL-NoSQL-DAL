using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Venue { get; set; }
        public DateTime Date { get; set; }

        public List<EventSection> EventSections { get; set; } = new List<EventSection>();
    }
}
