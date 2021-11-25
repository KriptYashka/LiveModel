using System;
using System.Collections;
using System.Collections.Generic;
using DemographicFileOperations;

namespace DemographicModel
{
    public class Person
    {

        public delegate void PersonHandler(Person sender);
        public event PersonHandler birthEvent, deathEvent;

        public int age { get; set; }
        public int dateBirth { get; set; }
        public int dateDeath { get; set; }
        public Sex sex { get; set; }
        public bool isAlive;
        private double birth_procentage, death_procentage;
        private readonly int young = Convert.ToInt32(Generation.young);
        private readonly int middle = Convert.ToInt32(Generation.middle);
        private const double birthProcentage = 0.151;

        public Person(int age, Sex sex, int year)
        {
            this.dateBirth = year - age;
            this.isAlive = true;
            this.age = age;
            this.sex = sex;
            this.death_procentage = GetDeathChance(age);
            birth_procentage = (sex == Sex.female && (age >= young && age <= middle) ? birthProcentage : 0);
        }

        public void NextYear() // Обработчик события
        {
            if (StatRandom.IsEventHappened(birth_procentage))
            {
                birthEvent?.Invoke(this);
            }
            if (StatRandom.IsEventHappened(death_procentage))
            {
                deathEvent?.Invoke(this);
                return;
            }
            
            age++;
            birth_procentage = (sex == Sex.female && (age >= young && age <= middle) ? birthProcentage : 0);
            death_procentage = GetDeathChance(age);
        }

        private double GetDeathChance(int age)
        {
            FilesController fc = new FilesController();
            List<List<double>> deathProbability = fc.GetDeathRules();
            int l = 0, r = deathProbability.Count;
            int index = r / 2;
            int fromAge = Convert.ToInt32(deathProbability[index][0]);
            int toAge = Convert.ToInt32(deathProbability[index][1]);
            while (l <= r)
            {
                if (age > toAge)
                {
                    l = index + 1;
                }
                else if (age < fromAge)
                {
                    r = index - 1;
                }
                else
                {
                    break;
                }
                index = (l + r) / 2;
                fromAge = Convert.ToInt32(deathProbability[index][0]);
                toAge = Convert.ToInt32(deathProbability[index][1]);
            }
            return (this.sex == Sex.male ? deathProbability[index][2] : deathProbability[index][3]);
        }


    }

}
