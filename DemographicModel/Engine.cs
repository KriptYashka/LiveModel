using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemographicFileOperations;

namespace DemographicModel
{
    public class Engine
    {
        public delegate void PersonHandler();
        public event PersonHandler events;
        private List<Person> populate;
        public Dictionary<int, double> initAgeProbability { set; get; }
        private int currentYear { get; set; }

        private int group = 1000; // По сколько человек будем группировать

        public void NextYear()
        {
            currentYear++;
            events?.Invoke();
        }

        public void ModelTime(int from, int to, int count)
        {
            count /= group;
            currentYear = from;
            InitPerson(count);
            for (int year = from; year <= to; ++year)
            {
                NextYear();
            }
        }

        private void InitPerson(int count)
        {
            if (initAgeProbability == null)
            {
                FilesController fc = new FilesController();
                initAgeProbability = fc.GetInitProbability();
            }
            populate = new List<Person>();
            foreach (int age in initAgeProbability.Keys)
            {
                double p = initAgeProbability[age];
                int currentCount = Convert.ToInt32(p * (count / group));
                for (int i = 0; i <= currentCount / 2; ++i)
                {
                    AddPerson(age, Sex.male);
                }
                for (int i = (currentCount / 2) + 1; i < currentCount; ++i)
                {
                    AddPerson(age, Sex.female);
                }
            } 
        }

        private void AddPerson(int age, Sex sex)
        {
            Person human = new Person(age, sex, currentYear);
            events += human.NextYear;
            human.birthEvent += Birth;
            human.deathEvent += Death;
            populate.Add(human);
        }

        public void Birth(Person sender)
        {
            var rand = new Random();
            double p = rand.NextDouble();
            Sex sex = (p <= 0.45 ? Sex.male : Sex.female);
            AddPerson(0, sex);
        }

        public void Death(Person sender)
        {
            sender.isAlive = false;
            sender.dateDeath = currentYear;
            // Отписываем
            events -= sender.NextYear;
            sender.birthEvent -= Birth;
            sender.birthEvent -= Death;
            populate.Remove(sender);
        }
    }
}
