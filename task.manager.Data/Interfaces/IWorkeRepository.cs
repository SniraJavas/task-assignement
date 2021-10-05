using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.manager.Data.Interfaces
{
    public interface IWorkeRepository
    {
        IEnumerable<Task.manager.Data.Models.Worker> getWorkers();
        Task.manager.Data.Models.Worker GetWorkerById(int id);
        void createTask(Task.manager.Data.Models.Worker worker);
        void updateTask(Task.manager.Data.Models.Worker worker);
        void deleteTask(int id);
        void save();
    }
}
