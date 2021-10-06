using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Models;

namespace Task.manager.Data.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public ManagerRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public ManagerRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

        Manager IManagerRepository.createManager(Manager manager)
        {
            try
            {
                
                _dbContext.Managers.Add(manager);
                
                save();
                return manager;
            }
            catch (Exception ex) {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }

        }

        private void save()
        {
            _dbContext.SaveChanges();
        }

        void IManagerRepository.deleteManager(int id)
        {
            var manager = _dbContext.Managers.Find(id);
            if (manager != null) _dbContext.Managers.Remove(manager);
        }

        Manager IManagerRepository.getManagerById(int id)
        {
            return _dbContext.Managers.Find(id);
        }

        IEnumerable<Manager> IManagerRepository.getManagers()
        {
            return _dbContext.Managers.ToList();
        }

        void IManagerRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void IManagerRepository.updateManager(Manager manager)
        {
            _dbContext.Entry(manager).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Exist(int id)
        {
            return _dbContext.Managers.Find(id) != null;

        }
    }
}
