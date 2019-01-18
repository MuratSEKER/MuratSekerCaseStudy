using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuratSekerCaseStudy.Data.Entities
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        
    }
}
