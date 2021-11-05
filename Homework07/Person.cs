using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07
{
    class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public Sex sex;
        public DateTime createdDate = DateTime.Now;
        public Person(string firstName, string lastName, int age, Sex sex)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.sex = sex;
        }
        public Person()
        {

        }
    }
    enum Sex
    {
        Male,
        Female
    }

}
