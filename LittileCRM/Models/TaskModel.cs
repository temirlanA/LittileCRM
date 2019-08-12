using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittileCRM.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DonePercent { get; set; }
        public int ComplexityId { get; set; }
        public string ComplexityName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeedName { get; set; }
    }
}
