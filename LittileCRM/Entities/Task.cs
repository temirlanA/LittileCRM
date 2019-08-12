using System;
using System.Collections.Generic;

namespace LittileCRM.Entities
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DonePercent { get; set; } 
        public int ComplexityId { get; set; }
        public int EmplyeeId { get; set; }

        public virtual Complexity Complexity { get; set; }
        public virtual Emplyee Emplyee { get; set; }
    }
}
