using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;

namespace Task.manager.Data.Interfaces
{
    public interface IWorkeRepository
    {
        IEnumerable<Worker> getWorkers();
        Worker GetWorkerById(int id);
        void createTask(Worker worker);
        void updateTask(Worker worker);
        void deleteTask(int id);
        void save();
    }
}
