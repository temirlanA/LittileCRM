using LittileCRM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LittileCRM.Models
{
    public class RegisterModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
        public string RoleName { get; set; }

        public int EmplyeeId { get; set; }
        public Emplyee Emplyee { get; set; }
    }
}
