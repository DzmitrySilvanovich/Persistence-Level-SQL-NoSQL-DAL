using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    public class SectionSeat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public int State { get; set; }

        public int EventSectionId { get; set; }
        public EventSection? EventSection { get; set; }
    }
}
