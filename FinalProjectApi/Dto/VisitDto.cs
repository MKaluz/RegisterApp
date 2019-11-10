using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Dto
{
    public class VisitDto
    {
        public VisitDate VisitDate { get; set; }
        public VisitLocation VisitLocation { get; set; }
        public int Patient { get; set; }
        public VisitType VisitType { get; set; }
    }
}
