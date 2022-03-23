using System;
using System.Collections.Generic;
using System.Text;

namespace PanAPIModel
{
    public class APIModel
    {
        public string Name { get; set; }
        public string LocalName { get; set; }
        public DateTime? Date { get; set; }
        public string CountryCode { get; set; }
        public bool Global { get; set; }
    }
}
