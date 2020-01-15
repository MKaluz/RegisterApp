using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApi.Entity
{
    public class Visit
    {
        public int Id { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public int Patient { get; set; }
        public string Type { get; set; }
    }
}
