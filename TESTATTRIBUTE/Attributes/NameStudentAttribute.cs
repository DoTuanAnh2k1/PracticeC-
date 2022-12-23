using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    [AttributeUsage(AttributeTargets.All)]
    public class NameStudentAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            
            string name = (string)value;

            if (name.Length >= 20 || name.Length == 0)
            {
                return false;
            }

            string[] p = name.Split(" ");
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i][0] < 65 || p[i][0] > 90)
                {
                    return false;
                }
            }

            return true;
        }

        public override string FormatErrorMessage(string name) 
        {
            return "Name Incorrect";
        }
    }
}
