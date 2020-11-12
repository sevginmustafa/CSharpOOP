using System;

namespace _06.ValidPerson
{
    class Person
    {
        string firstName;
        string lastName;
        int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The first name cannot be null or empty.");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The last name cannot be null or empty.");
                }

                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new Exception("Age should be in the range [0 . . . 120].");
                }

                age = value;
            }
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} is {age} years old.";
        }
    }
}
