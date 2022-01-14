using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application1.Models
{
    public class Filter
    {
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductMinPrice { get; set; }
        public int? ProductMaxPrice { get; set; }
        public int? ProductMinStock { get; set; }

        
    }


}
