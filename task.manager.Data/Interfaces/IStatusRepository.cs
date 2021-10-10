using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.manager.Data.Interfaces
{
    public interface IStatusRepository
    {

        IEnumerable<task.manager.data.Models.Status> getStatuses();
        task.manager.data.Models.Status GetStatusById(int id);
        void createStatus(task.manager.data.Models.Status status);
        void updateStatus(task.manager.data.Models.Status status);
        void deleteStatus(int id);
        void save();
    }
}
