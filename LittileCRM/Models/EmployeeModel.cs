using LittileCRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittileCRM.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public string PositionName { get; set; }
    }
}
