using Microsoft.AspNetCore.Mvc;
using System;
using Task.manager.Data.Interfaces;
using task.manager.data.Models;
using Xunit;

namespace task.manager.tests
{
    public class TasksControllerTests
    {
        private readonly ITaskRepository _taskRepository;

        public TasksControllerTests(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [Fact]
        public async void GetAllTasks()
        {

            var tasks = await _taskRepository.getTasks();

            Assert.IsType<OkObjectResult>(tasks.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Get_Existing_By_Id(int id)
        {

            var tasks = await _taskRepository.GetTaskById(id);

            Assert.IsType<OkObjectResult>(tasks.Value);

        }

        [Theory]
        [InlineData(7890)]
        public async void Get_Non_Existing_By_Id(int id)
        {

            var task = await _taskRepository.GetTaskById(id);

            Assert.IsType<NotFoundObjectResult>(task.Value);

        }

        [Fact]
        public async void Post_Task_Good_Format()
        {
            task.manager.data.Models.Task task = new task.manager.data.Models.Task()
            {
                Id = 3,
                Name = "Clean House",
                Active = true,
                ManagerId = 2,
                Remaining = 30,

            };
            var tasks = await _taskRepository.createTask(task);

            Assert.IsType<CreatedAtActionResult>(tasks.Value);

        }

        [Fact]
        public async void Post_Task_Bad_Format()
        {
            var task = new Object()
            {

            };
            var tasks = await _taskRepository.createTask((task.manager.data.Models.Task)task);

            Assert.IsType<BadRequestObjectResult>(tasks.Value);

        }

        [Theory]
        [InlineData(20)]
        public async void Delete_Existing_Task(int id)
        {

            var tasks = await _taskRepository.deleteTask(id);

            Assert.IsType<OkObjectResult>(tasks.Value);

        }

        [Theory]
        [InlineData(201202)]
        public async void Delete_Non_Existing_Task(int id)
        {
            var tasks = await _taskRepository.deleteTask(id);

            Assert.IsType<BadRequestResult>(tasks.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Task_Good_Format(int id)
        {
            task.manager.data.Models.Task task = new task.manager.data.Models.Task()
            {
                Id = 3,
                Name = "Clean House",
                Active = true,
                ManagerId = 2,
                Remaining = 30,

            };
            var tasks = await _taskRepository.updateTask(task);

            Assert.IsType<CreatedAtActionResult>(tasks.Value);

        }

        [Theory]
        [InlineData(3)]
        public async void Edit_Task_Bad_Format(int id)
        {
            var task = new Object()
            {

            };
            var tasks = await _taskRepository.updateTask((task.manager.data.Models.Task)task);

            Assert.IsType<CreatedAtActionResult>(tasks.Value);

        }


    }
}
