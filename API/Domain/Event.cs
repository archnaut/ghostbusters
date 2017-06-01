using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OnSaleDate { get; set; }
        public DateTime StarteDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DoorsOpenDate { get; set; }
    }
}