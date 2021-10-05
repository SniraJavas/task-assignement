using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.manager.Data.Interfaces
{
    public interface IStatusRepository
    {

        IEnumerable<Task.manager.Data.Models.Status> getStatuses();
        Task.manager.Data.Models.Status GetStatusById(int id);
        void createStatus(Task.manager.Data.Models.Status status);
        void updateStatus(Task.manager.Data.Models.Status status);
        void deleteStatus(int id);
        void save();
    }
}
