using Microsoft.AspNetCore.Mvc;
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
        Task<ActionResult<IEnumerable<Manager>>> getManagers();
        Task<ActionResult<Manager>> getManagerById(int id);
        Task<ActionResult<Manager>> createManager(Manager manager);
        Task<ActionResult<Manager>> updateManager(Manager manager);
        Task<ActionResult<Manager>> deleteManager(int id);
        void save();
        bool Exist(int id);
    }
}
