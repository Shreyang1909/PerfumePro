using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PerfumePro.Models
{
    public class PerfumeBrandViewModel
    {
        public List<Perfume> Perfumes { get; set; }
        public SelectList Brands { get; set; }
        public string PerfumeBrand { get; set; }
        public string SearchString { get; set; }
    }
}
