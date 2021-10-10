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
    public class WorkerRepository : IWorkeRepository
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
        void IWorkeRepository.createTask(Worker worker)
        {
            _dbContext.Workers.Add(worker);
            save();
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }


        void IWorkeRepository.deleteTask(int id)
        {
            var manager = _dbContext.Managers.Find(id);
            if (manager != null) _dbContext.Managers.Remove(manager);
        }

        Worker IWorkeRepository.GetWorkerById(int id)
        {
            return _dbContext.Workers.Find(id);
        }

        IEnumerable<Worker> IWorkeRepository.getWorkers()
        {
            return _dbContext.Workers.ToList();
        }

        void IWorkeRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void IWorkeRepository.updateTask(Worker worker)
        {
            _dbContext.Entry(worker).State = EntityState.Modified;
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
    }
}
