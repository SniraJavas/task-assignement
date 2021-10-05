using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.manager.Data.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task.manager.Data.Models.Task> getTasks();
        Task.manager.Data.Models.Task GetTaskById(int id);
        void createTask(Task.manager.Data.Models.Task task);
        void updateTask(Task.manager.Data.Models.Task task);
        void deleteTask(int id);
        void save();
    }
}
