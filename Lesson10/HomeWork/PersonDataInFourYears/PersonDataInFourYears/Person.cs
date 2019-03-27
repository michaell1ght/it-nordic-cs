using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDataInFourYears
{
    class Person
    {
        const int yearIncrement = 4;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
            }
        }
        public int Age { get; set; }
        public int AgeInFourYears
        {
            get
            {
                return Age + yearIncrement;
            }
         }

        public string NameAndAgeInForYears
        {
            get
            {
                return $" {Name}, age in 4 years: {AgeInFourYears}";
            }
        }
    }
}
