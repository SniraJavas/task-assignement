using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;

namespace Task.manager.Data.Interfaces
{
    public interface IWorkerRepository
    {
        Task<ActionResult<IEnumerable<Worker>>> getWorkers();
        Task<ActionResult<Worker>> getWorkerById(int id);
        Task<ActionResult<Worker>> createWorker(Worker worker);
        Task<ActionResult<Worker>> updateWorker(Worker worker);
        Task<ActionResult<Worker>> deleteWorker(int id);
        void save();
        bool Exist(int id);
    }
}
