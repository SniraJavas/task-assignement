using System;
using System.Collections.Generic;

#nullable disable

namespace task.manager.data.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Estimation { get; set; }
        public bool Active { get; set; }
        public decimal? Remaining { get; set; }
        public int ManagerId { get; set; }
        public int StatusId { get; set; }
        public int ProjectId { get; set; }
        public int? MemberId { get; set; }

        //public virtual Manager Manager { get; set; }
        //public virtual Worker Member { get; set; }
        //public virtual Project Project { get; set; }
        //public virtual Status Status { get; set; }
    }
}
