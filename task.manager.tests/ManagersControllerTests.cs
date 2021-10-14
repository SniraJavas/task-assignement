using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Repository;
using Xunit;

namespace task.manager.tests
{
    public class ManagersControllerTests
    {
        private readonly IManagerRepository _managerRepository;

        public ManagersControllerTests(IManagerRepository managerRepository) 
        {
            _managerRepository = managerRepository;
        }

        [Fact]
        public async void GetAllManagers()
        {

            var managers = await _managerRepository.getManagers();

            Assert.IsType<OkObjectResult>(managers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Get_Existing_By_Id(int id)
        {

            var managers = await _managerRepository.getManagerById(id);

            Assert.IsType<OkObjectResult>(managers.Value);

        }

        [Theory]
        [InlineData(7890)]
        public async void Get_Non_Existing_By_Id(int id)
        {

            var manager = await _managerRepository.getManagerById(id);

            Assert.IsType<NotFoundObjectResult>(manager.Value);

        }

        [Fact]
        public async void Post_Manager_Good_Format()
        {
            Manager manager = new Manager()
            {
                Name = "Sizo",
                Surname = "Ndovela",
                Active = true,
                Email = "ndovie@gumail.com",
                Id = 20
            };
            var managers = await _managerRepository.createManager(manager);

            Assert.IsType<CreatedAtActionResult>(managers.Value);

        }

        [Fact]
        public async void Post_Manager_Bad_Format()
        {
            var manager = new Object ()
            {
                
            };
            var managers = await _managerRepository.createManager((Manager)manager);

            Assert.IsType<BadRequestObjectResult>(managers.Value);

        }

        [Theory]
        [InlineData(20)]
        public async void Delete_Existing_Manager(int id)
        {

            var managers = await _managerRepository.deleteManager(id);

            Assert.IsType<OkObjectResult>(managers.Value);

        }

        [Theory]
        [InlineData(201202)]
        public async void Delete_Non_Existing_Manager(int id)
        {
            var managers = await _managerRepository.deleteManager(id);

            Assert.IsType<BadRequestResult>(managers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Manager_Good_Format(int id)
        {
            Manager manager = new Manager()
            {
                Name = "Sizo",
                Surname = "Ndovela",
                Active = true,
                Email = "ndovie@gumail.com",
                Id = 2
            };
            var managers = await _managerRepository.updateManager(manager);

            Assert.IsType<CreatedAtActionResult>(managers.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Manager_Bad_Format(int id)
        {
            var manager = new Object()
            {
                
            };
            var managers = await _managerRepository.updateManager((Manager)manager);

            Assert.IsType<CreatedAtActionResult>(managers.Value);

        }


    }
}
