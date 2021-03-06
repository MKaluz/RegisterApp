﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Services
{
    public interface IVisitService
    {
        IEnumerable<Visit> GetAllVisits();
        IEnumerable<Visit> GetAllAvailableVisits();
        IEnumerable<Visit> GetAllUsersAvailableVisits(int userId);
        Visit GetVisitById(int id);

        void Add(Visit visit);
        void Update(Visit visit);
        void Delete(Visit visit);
        bool VisitExist(int id);

        
    }
}
