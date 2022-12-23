using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    [AttributeUsage(AttributeTargets.All)]
    public class EmailStudentAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            string email = (string)value;
            if (email.Length == 0)
            {
                return false;
            }
            int count = 0;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == 64)
                {
                    count++;
                }
            }

            if (count != 1)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string email)
        {
            return "Email Incorrect";
        }
    }
}
