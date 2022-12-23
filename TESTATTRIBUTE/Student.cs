using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    public class Student
    {
        [NameStudent]
        public string Name { get; set; }
        [PhoneStudent]
        public string PhoneNumber { get; set; }
        [EmailStudent]
        public string Email { get; set; }
        [AgeStudent]
        public int Age { get; set; }
    }
}
