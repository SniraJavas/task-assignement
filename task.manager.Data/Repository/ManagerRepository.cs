using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;

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

        async Task<ActionResult<Manager>> IManagerRepository.createManager(Manager manager)
        {
            try
            {
                await _dbContext.Managers.AddAsync(manager);

                save();
                return manager;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }

        }

        private void save()
        {
            _dbContext.SaveChangesAsync();
        }

        async Task<ActionResult<Manager>> IManagerRepository.deleteManager(int id)
        {
            var manager = await _dbContext.Managers.FindAsync(id);
            if (manager != null)
            {
                if (manager.Active == true)
                {
                    manager.Active = false;
                    //_dbContext.Managers.Remove(manager);
                    _dbContext.Entry(manager).State = EntityState.Modified;
                    save();
                    return manager;
                }
            }

            return null;

        }

        async Task<ActionResult<Manager>> IManagerRepository.getManagerById(int id)
        {
            var manager = await _dbContext.Managers.FindAsync(id);
            if (manager != null)
            {
                if (manager.Active == true)
                {
                    return manager;
                }
            }
            return null;
        }

        void IManagerRepository.save()
        {
            _dbContext.SaveChanges();
        }

        async Task<ActionResult<Manager>> IManagerRepository.updateManager(Manager manager)
        {
            try
            {
                _dbContext.Entry(manager).State = EntityState.Modified;
                save();
                if (manager != null)
                {
                    if (manager.Active == true)
                    {
                        return manager;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }

        }



        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this._disposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }
        //    }
        //    this._disposed = true;
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        async Task<ActionResult<IEnumerable<Manager>>> IManagerRepository.getManagers()
        {
            return _dbContext.Managers.ToListAsync().Result.Where(x => x.Active == true).ToList(); ;
        }

        bool IManagerRepository.Exist(int id)
        {
            return _dbContext.Managers.Any(e => e.Id == id);
        }
    }
}
