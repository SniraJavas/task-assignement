using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Status.manager.Data.Interfaces;
using task.manager.api;
using task.manager.data.Models;
using Task.manager.Data.Interfaces;
using Task.manager.Data.Repository;
using Task.Project.Data.Interfaces;

namespace taskManager
{
    public class Startup
    {

        public DatabaseContext Context { set; get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //Below is for testing line
            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("TaskTracker"));
            services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Manager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "taskManager v1"));
            }

            //Below line contain using is for testing 
            using (var ServiceScope = app.ApplicationServices.CreateScope())
            {
                Context = ServiceScope.ServiceProvider.GetService<DatabaseContext>();
                AddTestData(Context);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            static void AddTestData(DatabaseContext context)
            {
                List<task.manager.data.Models.Status> statuses = new List<task.manager.data.Models.Status>()
                {
                    new task.manager.data.Models.Status(){ 
                        Id = 1,
                        Name = "To-do"
                    },
                    new task.manager.data.Models.Status(){
                        Id = 2,
                        Name = "In-progress"
                    },
                    new task.manager.data.Models.Status(){
                        Id = 3,
                        Name = "Review"
                    },
                    new task.manager.data.Models.Status(){
                        Id = 4,
                        Name = "Done"
                    }
                };

                List<Manager> managers = new List<Manager>()
                {
                    new Manager()
                    {
                        Id = 1,
                        Name = "Steve",
                        Surname = "Harvey",
                        Active = true,
                        Email = "Harvey@mail.com"
                    },
                    new Manager()
                    {
                        Id = 2,
                        Name = "John",
                        Surname = "Doe",
                        Active = true,
                        Email = "Doe@mail.com"
                    },
                    new Manager()
                    {
                        Id = 3,
                        Name = "Xola",
                        Surname = "Soyizwaphi",
                        Active = true,
                        Email = "Harvey@gmail.com"
                    },
                    new Manager()
                    {
                        Id = 4,
                        Name = "Beyonce",
                        Surname = "Picklic",
                        Active = true,
                        Email = "Picklic@gmail.com"
                    }
                };

                List<Worker> workers = new List<Worker>()
                {
                    new Worker(){ 
                        Id = 1,
                        Name = "Sinikiwe",
                        Surname = "Jumba",
                        Active = true,
                        Email = "jumb@mail.com"
                    },
                     new Worker(){
                        Id = 2,
                        Name = "Kiki",
                        Surname = "Marshmalow",
                        Active = true,
                        Email = "marsh@mail.com"
                    },
                      new Worker(){
                        Id = 3,
                        Name = "David",
                        Surname = "Sugar",
                        Active = true,
                        Email = "sugar@mail.com"
                    },
                       new Worker(){
                        Id = 4,
                        Name = "Christopher",
                        Surname = "Flower",
                        Active = true,
                        Email = "Flower@mail.com"
                    },
                       new Worker(){
                        Id = 5,
                        Name = "Maria",
                        Surname = "Puzza",
                        Active = true,
                        Email = "Flower@mail.com"
                    }
                };

                List<Project> projects = new List<Project>()
                {
                    new Project()
                    {
                        Id = 1,
                        Name = "Project A",
                        Duration = 75,
                        Active = true,
                        ManagerId = 3,
                        Remaining = 75
                    },
                    new Project()
                    {
                        Id = 2,
                        Name = "Project B",
                        Duration = 75,
                        Active = true,
                        ManagerId = 3,
                        Remaining = 75
                    },
                    new Project()
                    {
                        Id = 3,
                        Name = "Project C",
                        Duration = 75,
                        Active = true,
                        ManagerId = 3,
                        Remaining = 75
                    },
                    new Project()
                    {
                        Id = 4,
                        Name = "Project D",
                        Duration = 75,
                        Active = true,
                        ManagerId = 3,
                        Remaining = 75
                    }
                };

                List<task.manager.data.Models.Task> tasks = new List<task.manager.data.Models.Task>()
                {
                    new task.manager.data.Models.Task()
                    {
                        Id = 1,
                        Name = "Order Pizza",
                        Description = "Call xxx-xxx-xxxx and speak to Susan about aboutt our daily favoure",
                        Active = true,
                        Estimation = 24,
                        ManagerId = 3,
                        MemberId = 4,
                        ProjectId = 2,
                        Remaining  = 24,
                        StatusId = 1
                    },
                    new task.manager.data.Models.Task()
                    {
                        Id = 2,
                        Name = "Order Gaming PC",
                        Description = "Call xxx-xxx-xxxx and speak to John Miracles about aboutt our prefered Machines",
                        Active = true,
                        Estimation = 24,
                        ManagerId = 3,
                        MemberId = 2,
                        ProjectId = 1,
                        Remaining  = 24,
                        StatusId = 1
                    },
                    new task.manager.data.Models.Task()
                    {
                        Id = 3,
                        Name = "Design Sprint",
                        Description = "Do sprint planning for the upcoming project using Jira",
                        Active = true,
                        Estimation = 24,
                        ManagerId = 1,
                        MemberId = 1,
                        ProjectId = 4,
                        Remaining  = 24,
                        StatusId = 1
                    }
                };

                foreach (var status in statuses) {
                    context.Statuses.Add(status);
                }

                foreach (var manager in managers)
                {
                    context.Managers.Add(manager);
                }

                foreach (var work in workers)
                {
                    context.Workers.Add(work);
                }

                foreach (var project in projects)
                {
                    context.Projects.Add(project);
                }

                foreach (var task in tasks)
                {
                    context.Tasks.Add(task);
                }

                context.SaveChanges();
            }
        }
    }
}
