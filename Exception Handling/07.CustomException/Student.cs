using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.ValidPerson
{
    public class Student
    {
        string name;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.All(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException("The last name cannot be null or empty and must contain only letters");
                }

                name = value;
            }
        }
        public string Email { get; }

        public override string ToString()
        {
            return $"Name: {name}, Email: {Email}";
        }
    }
}
