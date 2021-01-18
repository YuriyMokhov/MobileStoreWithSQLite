using MobileStoreWithSQLite.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Utils
{
    public class PasswordNotEqualNameAttribute: ValidationAttribute
    {
        public PasswordNotEqualNameAttribute()
        {
            ErrorMessage = "Пароль не должен соответстовать имени, сука!";
        }
        public override bool IsValid(object value)
        {
            Person p = value as Person;
            if (p.Password == p.Name)
                return false;

            return true;
        }
    }
}
