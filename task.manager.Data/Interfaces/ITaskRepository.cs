using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;
namespace Task.manager.Data.Interfaces
{
    public interface ITaskRepository
    {
        Task<ActionResult<IEnumerable<task.manager.data.Models.Task>>> getTasks();
        Task<ActionResult<task.manager.data.Models.Task>> GetTaskById(int id);
        Task<ActionResult<task.manager.data.Models.Task>> createTask(task.manager.data.Models.Task task);
        Task<ActionResult<task.manager.data.Models.Task>> updateTask(task.manager.data.Models.Task task);
        Task<ActionResult<task.manager.data.Models.Task>> deleteTask(int id);
        void save();
        bool Exist(int id);
    }
}
