using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.manager.Data.Models;
using Task.Project.Data.Interfaces;

namespace Task.manager.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskManagerContext _dbContext;

        private bool _disposed = false;

        public ProjectRepository()
        {
            _dbContext = new TaskManagerContext();
        }

        public ProjectRepository(TaskManagerContext context)
        {
            _dbContext = context;
        }

        void IProjectRepository.createProject(Models.Project project)
        {
            _dbContext.Projects.Add(project);
            save();
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }


        void IProjectRepository.deleteProject(int id)
        {
            var manager = _dbContext.Managers.Find(id);
            if (manager != null) _dbContext.Managers.Remove(manager);
        }

        Models.Project IProjectRepository.getProjectrById(int id)
        {
            return _dbContext.Projects.Find(id);
        }

        IEnumerable<Models.Project> IProjectRepository.getProjects()
        {
            return _dbContext.Projects.ToList();
        }

        void IProjectRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void IProjectRepository.updateProject(Models.Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
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
