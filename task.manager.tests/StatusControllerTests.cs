
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Status.manager.Data.Interfaces;
using System;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Repository;
using Xunit;

namespace task.manager.tests
{
    public class StatusControllerTests
    {
        private readonly IStatusRepository _statusRepository;
        public StatusControllerTests(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [Fact]
        public async void GetAllStatuss()
        {

            var statuss = await _statusRepository.getStatuses();

            Assert.IsType<OkObjectResult>(statuss.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Get_Existing_By_Id(int id)
        {

            var statuss = await _statusRepository.GetStatusById(id);

            Assert.IsType<OkObjectResult>(statuss.Value);

        }

        [Theory]
        [InlineData(7890)]
        public async void Get_Non_Existing_By_Id(int id)
        {

            var status = await _statusRepository.GetStatusById(id);

            Assert.IsType<NotFoundObjectResult>(status.Value);

        }

        [Fact]
        public async void Post_Status_Good_Format()
        {
            task.manager.data.Models.Status status = new task.manager.data.Models.Status()
            {
                Id = 6,
                Name = "Unkown"

            };
            var statuss = await _statusRepository.createStatus(status);

            Assert.IsType<CreatedAtActionResult>(statuss.Value);

        }

        [Fact]
        public async void Post_Status_Bad_Format()
        {
            var status = new Object()
            {

            };
            var statuss = await _statusRepository.createStatus((task.manager.data.Models.Status)status);

            Assert.IsType<BadRequestObjectResult>(statuss.Value);

        }

        [Theory]
        [InlineData(20)]
        public async void Delete_Existing_Status(int id)
        {

            var statuss = await _statusRepository.deleteStatus(id);

            Assert.IsType<OkObjectResult>(statuss.Value);

        }

        [Theory]
        [InlineData(201202)]
        public async void Delete_Non_Existing_Status(int id)
        {
            var statuss = await _statusRepository.deleteStatus(id);

            Assert.IsType<BadRequestResult>(statuss.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Status_Good_Format(int id)
        {
            task.manager.data.Models.Status status = new task.manager.data.Models.Status()
            {
                Id = 6,
                Name = "unverified",
               

            };
            _statusRepository.updateStatus(status);

            Assert.IsType<CreatedAtActionResult>(status);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Status_Bad_Format(int id)
        {
            var status = new Object()
            {

            };
            _statusRepository.updateStatus((task.manager.data.Models.Status)status);
            var newStatus = _statusRepository.GetStatusById(id);

            Assert.IsType<OkObjectResult>(newStatus);

        }


    }
}

