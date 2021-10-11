using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.manager.Data.Interfaces
{
    public interface IStatusRepository
    {

        Task<ActionResult<IEnumerable<task.manager.data.Models.Status>>> getStatuses();
        Task<ActionResult<task.manager.data.Models.Status>> GetStatusById(int id);
        Task<ActionResult<task.manager.data.Models.Status>> createStatus(task.manager.data.Models.Status status);
        void updateStatus(task.manager.data.Models.Status status);
        Task<ActionResult<task.manager.data.Models.Status>> deleteStatus(int id);
        void save();
        bool Exist(int id);
    }
}
