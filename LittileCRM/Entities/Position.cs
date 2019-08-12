using System;
using System.Collections.Generic;

namespace LittileCRM.Entities
{
    public partial class Position
    {
        public Position()
        {
            Emplyee = new HashSet<Emplyee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Emplyee> Emplyee { get; set; }
    }
}
