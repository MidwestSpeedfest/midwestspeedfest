using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Enum = System.Enum;

namespace MWSFBlazorFrontEnd.Helpers.CustomDataValidators
{
    public class IsWithinEnumValidator : ValidationAttribute
    {
        public Type EnumToCheck;
        public int Value { get; set; }

        public override bool IsValid(object value)
        {
            try
            {
                return Enum.IsDefined(EnumToCheck, value);
            }
            catch
            {
                return false;
            }
            
        }
    }
}
