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
        IEnumerable<Task.manager.Data.Models.Project> getProjects();
        Task.manager.Data.Models.Project getProjectrById(int id);
        void createProject(Task.manager.Data.Models.Project project);
        void updateProject(Task.manager.Data.Models.Project project);
        void deleteProject(int id);
        void save();
    }
}
