﻿using System;
using System.Collections.Generic;

namespace LittileCRM.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int EmplyeeId { get; set; }

        public virtual Emplyee Emplyee { get; set; }
        public virtual Role Role { get; set; }
    }
}
