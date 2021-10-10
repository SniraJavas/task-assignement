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
        IEnumerable<task.manager.data.Models.Task> getTasks();
        task.manager.data.Models.Task GetTaskById(int id);
        void createTask(task.manager.data.Models.Task task);
        void updateTask(task.manager.data.Models.Task task);
        void deleteTask(int id);
        void save();
    }
}
