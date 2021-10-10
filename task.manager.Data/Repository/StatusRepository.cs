using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Status.manager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;

namespace Task.manager.Data.Repository
{
    public class StatusRepository : IStatusRepository
    {

        private readonly DatabaseContext _dbContext;

        private bool _disposed = false;

        public StatusRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public StatusRepository(DatabaseContext context)
        {
            _dbContext = context;
        }
        async Task<ActionResult<task.manager.data.Models.Status>> IStatusRepository.createStatus(task.manager.data.Models.Status status)
        {
            try
            {
                await _dbContext.Statuses.AddAsync(status);

                save();
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : {0} ", ex.Message);
                return null;
            }
        }

        private void save()
        {
            _dbContext.SaveChanges();
        }


        async Task<ActionResult<task.manager.data.Models.Status>> IStatusRepository.deleteStatus(int id)
        {
            try
            {
                var status = await _dbContext.Statuses.FindAsync(id);
                if (status != null)
                {

                    _dbContext.Statuses.Remove(status);

                    save();
                    return status;

                }

                return null;
            }
            catch (Exception ex) {
                Console.WriteLine(" error : ", ex.Message);
                return null;
            }
        }

        async Task<ActionResult<task.manager.data.Models.Status>> IStatusRepository.GetStatusById(int id)
        {
            var status = await _dbContext.Statuses.FindAsync(id);

            return status;

        }

        async Task<ActionResult<IEnumerable<task.manager.data.Models.Status>>> IStatusRepository.getStatuses()
        {
            return await _dbContext.Statuses.ToListAsync();
        }

        void IStatusRepository.save()
        {
            _dbContext.SaveChanges();
        }

        void  IStatusRepository.updateStatus(task.manager.data.Models.Status status)
        {
            try {
                _dbContext.Entry(status).State = EntityState.Modified;
                save();
              
            }
            catch (Exception ex) {
                Console.WriteLine(" error : ", ex.Message);
               
            }
           
        }

        bool IStatusRepository.Exist(int id)
        {
            return _dbContext.Statuses.Any(e => e.Id == id);

        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this._disposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }
        //    }
        //    this._disposed = true;
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
