using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Repository;
using Task.Project.Data.Interfaces;
using Xunit;

namespace task.manager.tests
{
    public class ProjectsControllerTests
    {
        private readonly IProjectRepository _projectRepository ;

        public ProjectsControllerTests(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [Fact]
        public async void GetAllProjects()
        {

            var projects = await _projectRepository.getProjects();

            Assert.IsType<OkObjectResult>(projects.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Get_Existing_By_Id(int id)
        {

            var projects = await _projectRepository.getProjectrById(id);

            Assert.IsType<OkObjectResult>(projects.Value);

        }

        [Theory]
        [InlineData(7890)]
        public async void Get_Non_Existing_By_Id(int id)
        {

            var project = await _projectRepository.getProjectrById(id);

            Assert.IsType<NotFoundObjectResult>(project.Value);

        }

        [Fact]
        public async void Post_Project_Good_Format()
        {
            Project project = new Project()
            {
                Id = 3,
                Name = "Clean House",
               Duration = 30,
               Active = true,
               ManagerId = 2,
               Remaining = 30,

            };
            var projects = await _projectRepository.createProject(project);

            Assert.IsType<CreatedAtActionResult>(projects.Value);

        }

        [Fact]
        public async void Post_Project_Bad_Format()
        {
            var project = new Object()
            {

            };
            var projects = await _projectRepository.createProject((Project)project);

            Assert.IsType<BadRequestObjectResult>(projects.Value);

        }

        [Theory]
        [InlineData(20)]
        public async void Delete_Existing_Project(int id)
        {

            var projects = await _projectRepository.deleteProject(id);

            Assert.IsType<OkObjectResult>(projects.Value);

        }

        [Theory]
        [InlineData(201202)]
        public async void Delete_Non_Existing_Project(int id)
        {
            var projects = await _projectRepository.deleteProject(id);

            Assert.IsType<BadRequestResult>(projects.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Project_Good_Format(int id)
        {
            Project project = new Project()
            {
                Id = 3,
                Name = "Clean House",
                Duration = 30,
                Active = true,
                ManagerId = 2,
                Remaining = 30,

            };
            var projects = await _projectRepository.updateProject(project);

            Assert.IsType<CreatedAtActionResult>(projects.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Project_Bad_Format(int id)
        {
            var project = new Object()
            {

            };
            var projects = await _projectRepository.updateProject((Project)project);

            Assert.IsType<CreatedAtActionResult>(projects.Value);

        }


    }
}
