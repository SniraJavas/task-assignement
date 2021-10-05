using System;
using System.Collections.Generic;

#nullable disable

namespace Task.manager.Data.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
