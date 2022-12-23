using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    [AttributeUsage(AttributeTargets.All)]
    public class AgeStudentAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            int age = (int)value;
            if (age < 18 || age > 25)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Age Incorrect";
        }
    }
}
