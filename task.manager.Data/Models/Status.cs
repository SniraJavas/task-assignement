using System;
using System.Collections.Generic;

#nullable disable

namespace task.manager.data.Models
{
    public partial class Status
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Task> Tasks { get; set; }
    }
}
