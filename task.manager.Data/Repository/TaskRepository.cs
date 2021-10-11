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
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public TaskRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public TaskRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

        async Task<ActionResult<task.manager.data.Models.Task>> ITaskRepository.createTask(task.manager.data.Models.Task task)
        {
            await _dbContext.Tasks.AddAsync(task);
            save();
            return task;
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }

        async Task<ActionResult<task.manager.data.Models.Task>> ITaskRepository.deleteTask(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
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

        async Task<ActionResult<task.manager.data.Models.Task>> ITaskRepository.GetTaskById(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                if (task.Active == true)
                {
                    return task;
                }
            }
            return null;
        }

        async Task<ActionResult<IEnumerable<task.manager.data.Models.Task>>> ITaskRepository.getTasks()
        {
            return await _dbContext.Tasks.ToListAsync(); ;
        }

        void ITaskRepository.save()
        {
            _dbContext.SaveChanges();
        }

        async Task<ActionResult<task.manager.data.Models.Task>> ITaskRepository.updateTask(task.manager.data.Models.Task task)
        {
            try
            {
                _dbContext.Entry(task).State = EntityState.Modified;
                save();
                if (task != null)
                {
                    if (task.Active == true)
                    {
                        return task;
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
    }
}
