using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Services
{
    public interface IVisitService
    {
        IEnumerable<Visit> GetAllVisits();
        Visit GetUserById(int id);
        void Add(Visit visit);
        void Update(Visit visit);
        void Delete(Visit visit);
        bool VisitExist(int id);

        
    }
}
