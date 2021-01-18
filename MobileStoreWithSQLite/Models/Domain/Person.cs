using MobileStoreWithSQLite.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Models.Domain
{
    [PasswordNotEqualName]
    public class Person
    {
        [Required(ErrorMessage = "Вводи имя сука!")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль сука")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Range(8,118, ErrorMessage = "Выберите адекватный возраст! сука")]
        [Display(Name = "Леток те скока сука?!")]
        public int Age { get; set; }
    }
}
