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
    public class WorkerRepository : IWorkerRepository
    {

        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public WorkerRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public WorkerRepository(DatabaseContext context)
        {
            _dbContext = context;
        }
        async Task<ActionResult<Worker>> IWorkerRepository.createWorker(Worker worker)
        {
            try
            {
                await _dbContext.Workers.AddAsync(worker);

                save();
                return worker;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }


        async Task<ActionResult<Worker>> IWorkerRepository.deleteWorker(int id)
        {
            var task = await _dbContext.Workers.FindAsync(id);
            if (task != null)
            {
                if (task.Active == true)
                {
                    task.Active = false;
                    //_dbContext.Managers.Remove(manager);
                    _dbContext.Entry(task).State = EntityState.Modified;
                    save();
                    return task;
                }
            }

            return null;
        }

        async Task<ActionResult<Worker>> IWorkerRepository.getWorkerById(int id)
        {
            var manager = await _dbContext.Workers.FindAsync(id);
            if (manager != null)
            {
                if (manager.Active == true)
                {
                    return manager;
                }
            }
            return null;
        }

        async Task<ActionResult<IEnumerable<Worker>>> IWorkerRepository.getWorkers()
        {
            return _dbContext.Workers.ToListAsync().Result.Where(x=> x.Active == true).ToList();
        }

        void IWorkerRepository.save()
        {
            _dbContext.SaveChanges();
        }

        async Task<ActionResult<Worker>> IWorkerRepository.updateWorker(Worker worker)
        {
            try
            {
                _dbContext.Entry(worker).State = EntityState.Modified;
                save();
                if (worker != null)
                {
                    if (worker.Active == true)
                    {
                        return worker;
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
            return _dbContext.Workers.Any(e => e.Id == id);
        }
    }
}
