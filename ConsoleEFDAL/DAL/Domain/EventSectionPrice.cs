using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    [Index(nameof(EventSectionId), nameof(PriceTypeId), IsUnique = true)]
    public class EventSectionPrice
    {

        public int Id { get; set; }

        public int EventSectionId { get; set; }
        public EventSection? EventSection { get; set; }
        public int PriceTypeId { get; set; }
        public PriceType? PriceType { get; set; }

        public decimal Price { get; set; }
    }
}
