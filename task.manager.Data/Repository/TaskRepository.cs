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
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _dbContext;

        private bool _disposed = false;

        public TaskRepository()
        {
            _dbContext = new TaskManagerContext();
        }

        public TaskRepository(TaskManagerContext context)
        {
            _dbContext = context;
        }

        void ITaskRepository.createTask(Models.Task task)
        {
            _dbContext.Tasks.Add(task);
            save();
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }

        void ITaskRepository.deleteTask(int id)
        {
            var task = _dbContext.Tasks.Find(id);
            if (task != null) _dbContext.Tasks.Remove(task);
        }

        Models.Task ITaskRepository.GetTaskById(int id)
        {
            return _dbContext.Tasks.Find(id);
        }

        IEnumerable<Models.Task> ITaskRepository.getTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        void ITaskRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void ITaskRepository.updateTask(Models.Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
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
