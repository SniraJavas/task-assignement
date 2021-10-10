using Microsoft.EntityFrameworkCore;
using Status.manager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;

namespace Task.manager.Data.Repository
{
    class StatusRepository : IStatusRepository
    {

        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public StatusRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public StatusRepository(DatabaseContext context)
        {
            _dbContext = context;
        }
        void IStatusRepository.createStatus(task.manager.data.Models.Status status)
        {
            _dbContext.Statuses.Add(status);
            save();
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }


        void IStatusRepository.deleteStatus(int id)
        {
            var manager = _dbContext.Managers.Find(id);
            if (manager != null) _dbContext.Managers.Remove(manager);
        }

        task.manager.data.Models.Status IStatusRepository.GetStatusById(int id)
        {
            return _dbContext.Statuses.Find(id);
        }

        IEnumerable<task.manager.data.Models.Status> IStatusRepository.getStatuses()
        {
            return _dbContext.Statuses.ToList();
        }

        void IStatusRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void IStatusRepository.updateStatus(task.manager.data.Models.Status status)
        {
            _dbContext.Entry(status).State = EntityState.Modified;
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
