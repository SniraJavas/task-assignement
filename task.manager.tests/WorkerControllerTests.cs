using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Xunit;

namespace task.manager.tests
{

    public class WorkerControllerTests
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerControllerTests(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [Fact]
        public async void GetAllWorkers()
        {

            var workers = await _workerRepository.getWorkers();

            Assert.IsType<OkObjectResult>(workers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Get_Existing_By_Id(int id)
        {

            var workers = await _workerRepository.getWorkerById(id);

            Assert.IsType<OkObjectResult>(workers.Value);

        }

        [Theory]
        [InlineData(7890)]
        public async void Get_Non_Existing_By_Id(int id)
        {

            var worker = await _workerRepository.getWorkerById(id);

            Assert.IsType<NotFoundObjectResult>(worker.Value);

        }

        [Fact]
        public async void Post_Worker_Good_Format()
        {
            Worker worker = new Worker()
            {
                Id = 3,
                Name = "Chris",
                Surname = "James",
                Active = true,
                Email = "Miami@hozzet.com"


            };
            var workers = await _workerRepository.createWorker(worker);

            Assert.IsType<CreatedAtActionResult>(workers.Value);

        }

        [Fact]
        public async void Post_Worker_Bad_Format()
        {
            var worker = new Object()
            {

            };
            var workers = await _workerRepository.createWorker((Worker)worker);

            Assert.IsType<BadRequestObjectResult>(workers.Value);

        }

        [Theory]
        [InlineData(20)]
        public async void Delete_Existing_Worker(int id)
        {

            var workers = await _workerRepository.deleteWorker(id);

            Assert.IsType<OkObjectResult>(workers.Value);

        }

        [Theory]
        [InlineData(201202)]
        public async void Delete_Non_Existing_Worker(int id)
        {
            var workers = await _workerRepository.deleteWorker(id);

            Assert.IsType<BadRequestResult>(workers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Worker_Good_Format(int id)
        {
            Worker worker = new Worker()
            {
                Id = 3,
                Name = "Chris",
                Surname = "James",
                Active = true,
                Email = "Miami@hozzet.com"

            };
            var workers = await _workerRepository.updateWorker(worker);

            Assert.IsType<CreatedAtActionResult>(workers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Worker_Bad_Format(int id)
        {
            var worker = new Object()
            {

            };
            var workers = await _workerRepository.updateWorker((Worker)worker);

            Assert.IsType<CreatedAtActionResult>(workers.Value);

        }

    }
}
