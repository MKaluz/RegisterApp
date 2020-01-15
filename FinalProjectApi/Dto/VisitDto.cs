using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Dto
{
    public class VisitDto
    {
       
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int Patient { get; set; }
        public string Type { get; set; }
    }
}
