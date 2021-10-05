using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.manager.Data.Models;

namespace Task.manager.Data.Interfaces
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> getManagers();
        Manager getManagerById(int id);
        Manager createManager(Manager manager);
        void updateManager(Manager manager);
        void deleteManager(int id);
        void save();
        bool Exist(int id);
    }
}
