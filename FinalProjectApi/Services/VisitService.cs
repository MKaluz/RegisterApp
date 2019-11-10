using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Services
{
    public class VisitService : IVisitService
    {
        private readonly IRepository<Visit> _repository;

        public VisitService(IRepository<Visit> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Visit> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public Visit GetUserById(int id)
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
