using System;
using System.Collections.Generic;

namespace LittileCRM.Entities
{
    public partial class Complexity
    {
        public Complexity()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
