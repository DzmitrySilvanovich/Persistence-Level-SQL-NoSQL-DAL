using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    public class PriceType
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public EventSectionPrice? EventSectionPrice { get; set; }
        public EventSeatPrice? EventSeatPricePrice { get; set; }
    }
}
