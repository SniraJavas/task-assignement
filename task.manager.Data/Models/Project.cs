using System;
using System.Collections.Generic;

#nullable disable

namespace Task.manager.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public decimal Duration { get; set; }
        public decimal Remaining { get; set; }
        public int ManagerId { get; set; }
        public int WorkerId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
