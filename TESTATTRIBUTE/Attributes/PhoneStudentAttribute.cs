using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    [AttributeUsage(AttributeTargets.All)]
    public class PhoneStudentAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            string phone = (string)value;
            if (phone.Length == 0 || phone.Length > 10) 
            {
                return false;
            }

            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i] < 48 || phone[i] > 57)
                {
                    return false;
                }
            }

            return true;
        }

        public override string FormatErrorMessage(string phone)
        {
            return "Phone Incorrect";
        }
    }
}
