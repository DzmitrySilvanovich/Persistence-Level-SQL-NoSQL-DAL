using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    [Index(nameof(SectionSeatId), nameof(PriceTypeId), IsUnique = true)]
    public class EventSeatPrice
    {
        public int Id { get; set; }

        public int SectionSeatId { get; set; }
        public SectionSeat? SectionSeat { get; set; }
        public int PriceTypeId { get; set; }
        public PriceType? PriceType { get; set; }
        public decimal Price { get; set; }
    }
}
