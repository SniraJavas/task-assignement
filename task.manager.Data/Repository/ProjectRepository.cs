using Microsoft.AspNetCore.Mvc;
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
        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public ProjectRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public ProjectRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

       
        
        void save()
        {
            _dbContext.SaveChanges();
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

        async Task<ActionResult<IEnumerable<Models.Project>>> IProjectRepository.getProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        async Task<ActionResult<Models.Project>> IProjectRepository.getProjectrById(int id)
        {

            var manager = await _dbContext.Projects.FindAsync(id);
            if (manager != null)
            {
                if (manager.Active == true)
                {
                    return manager;
                }
            }
            return null;
        }

        async Task<ActionResult<Models.Project>> IProjectRepository.createProject(Models.Project project)
        {
            try
            {
                await _dbContext.Projects.AddAsync(project);

                save();
                return project;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }

        }

        async Task<ActionResult<Models.Project>> IProjectRepository.updateProject(Models.Project project)
        {
            try
            {
                _dbContext.Entry(project).State = EntityState.Modified;
                save();
                if (project != null)
                {
                    if (project.Active == true)
                    {
                        return project;
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

        async Task<ActionResult<Models.Project>> IProjectRepository.deleteProject(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project != null)
            {
                if (project.Active == true)
                {
                    project.Active = false;
                    //_dbContext.Projects.Remove(manager);
                    _dbContext.Entry(project).State = EntityState.Modified;
                    save();
                    return project;
                }
            }

            return null;
        }

        void IProjectRepository.save()
        {
            throw new NotImplementedException();
        }


        bool IProjectRepository.Exist(int id)
        {
            return _dbContext.Managers.Any(e => e.Id == id);
        }
    }
}
