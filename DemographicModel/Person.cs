using System;

namespace DemographicModel
{
    public class Person
    {

        public delegate void PersonHandler(string message);
        public event PersonHandler Notify;

        private int age { get; set; }
        private Sex sex;
        private double birth_procentage, death_procentage;

        public Person(int age, Sex sex)
        {
            this.age = age;
            this.sex = sex;
            if (sex == Sex.female && (age >= 18 && age <= 45))
            {
                birth_procentage = 0.151;
            }
        }

        private
    }
}
