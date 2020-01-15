using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;
using FinalProjectApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectApi.Services
{
    public class VisitService : IVisitService
    {
        private readonly IRepository<Visit> _repository;
        private readonly DataContext _context;


        public VisitService(IRepository<Visit> repository, DataContext context)
        {
            _repository = repository;
            _context = context;
        }
        public IEnumerable<Visit> GetAllVisits()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Visit> GetAllAvailableVisits()
        {
            return _context.Visits.Where(v => v.StartTime > DateTime.UtcNow && v.Patient == 0)
                .OrderByDescending(v => v.StartTime);

        }

        public IEnumerable<Visit> GetAllUsersAvailableVisits(int userId)
        {
            return _context.Visits.Where(v => v.Patient == userId)
                .OrderByDescending(v => v.StartTime);

        }

        public Visit GetVisitById(int id)
        {
            return _repository.Get(id);
        }

        public void Add(Visit visit)
        {
            _repository.Add(visit);
        }

        public void Update(Visit visit)
        {
            _repository.Update(visit);
        }

        public void Delete(Visit visit)
        {
            _repository.Delete(visit);
        }

        public bool VisitExist(int id)
        {
            return _repository.GetAll().Any(u => u.Id == id);
        }

    }
}
