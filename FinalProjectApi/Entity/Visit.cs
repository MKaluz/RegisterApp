using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApi.Entity
{
    public class Visit
    {
        public int Id { get; set; }
        public VisitDate VisitDate { get; set; }
        public VisitLocation VisitLocation { get; set; }
        public int Patient { get; set; }
        public VisitType VisitType { get; set; }
    }
}
