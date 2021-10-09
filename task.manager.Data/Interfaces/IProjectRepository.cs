using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.manager.Data.Models;
namespace Task.Project.Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<ActionResult<IEnumerable<Task.manager.Data.Models.Project>>> getProjects();
        Task<ActionResult<Task.manager.Data.Models.Project>> getProjectrById(int id);
        Task<ActionResult<Task.manager.Data.Models.Project>> createProject(Task.manager.Data.Models.Project project);
        Task<ActionResult<Task.manager.Data.Models.Project>> updateProject(Task.manager.Data.Models.Project project);
        Task<ActionResult<Task.manager.Data.Models.Project>> deleteProject(int id);
        void save();
        bool Exist(int id);
    }
}
