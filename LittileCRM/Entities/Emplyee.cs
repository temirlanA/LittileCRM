using System;
using System.Collections.Generic;

namespace LittileCRM.Entities
{
    public partial class Emplyee
    {
        public Emplyee()
        {
            Task = new HashSet<Task>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
