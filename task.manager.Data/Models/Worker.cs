using System;
using System.Collections.Generic;

#nullable disable

namespace task.manager.data.Models
{
    public partial class Worker
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        //public virtual ICollection<Task> Tasks { get; set; }
    }
}
