using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task.Project.Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<ActionResult<IEnumerable<task.manager.data.Models.Project>>> getProjects();
        Task<ActionResult<task.manager.data.Models.Project>> getProjectrById(int id);
        Task<ActionResult<task.manager.data.Models.Project>> createProject(task.manager.data.Models.Project project);
        Task<ActionResult<task.manager.data.Models.Project>> updateProject(task.manager.data.Models.Project project);
        Task<ActionResult<task.manager.data.Models.Project>> deleteProject(int id);
        void save();
        bool Exist(int id);
    }
}
