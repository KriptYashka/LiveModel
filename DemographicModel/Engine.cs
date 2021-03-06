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
        public delegate void PrograssBarHandler(int p);
        public event PersonHandler events;
        public event PrograssBarHandler loading;
        private List<Person> populate;
        public Dictionary<int, double> initAgeProbability { set; get; }
        private int currentYear { get; set; }
        private const double birthMaleProbability = 0.45;
        private const int group = 1000; // По сколько человек будем группировать
        Dictionary<TypeData, Dictionary<int, int>> data;

        public Engine()
        {
            data = new Dictionary<TypeData, Dictionary<int, int>>();
        }
        public void NextYear()
        {
            events?.Invoke();
        }

        public void ModelTime(int from, int to, int count)
        {
            count /= group;
            currentYear = from;
            InitPerson(count);

            data.Clear();
            Dictionary<int, int> general = new Dictionary<int, int>();
            Dictionary<int, int> gmale = new Dictionary<int, int>();
            Dictionary<int, int> gfemale = new Dictionary<int, int>();
            double proc = 100 / Convert.ToDouble(to - from);
            for (currentYear = from; currentYear <= to; ++currentYear)
            {
                int maleCount = populate.Where(t => t.sex == Sex.male && t.isAlive).Count();
                int femaleCount = populate.Where(t => t.sex == Sex.female && t.isAlive).Count();
                general.Add(currentYear, (maleCount + femaleCount) * group);
                gmale.Add(currentYear, maleCount * group);
                gfemale.Add(currentYear, femaleCount * group);
                NextYear();
                loading?.Invoke(Convert.ToInt32(proc * (currentYear - from)));
            }
            Dictionary<int, int> ageMale = new Dictionary<int, int>();
            Dictionary<int, int> ageFemale = new Dictionary<int, int>();

            int young = Convert.ToInt32(Generation.young);
            int middle = Convert.ToInt32(Generation.middle);
            int adult = Convert.ToInt32(Generation.adult);

            ageMale.Add(Convert.ToInt32(TypeData.youngMale),
                populate.Where(t => t.age <= young && t.isAlive && t.sex == Sex.male).Count() * group);
            ageMale.Add(Convert.ToInt32(TypeData.middleMale),
                populate.Where(t => t.age > young && t.age <= middle && t.isAlive && t.sex == Sex.male).Count() * group);
            ageMale.Add(Convert.ToInt32(TypeData.adultMale),
                populate.Where(t => t.age > middle && t.age <= adult && t.isAlive && t.sex == Sex.male).Count() * group);
            ageMale.Add(Convert.ToInt32(TypeData.oldMale),
                populate.Where(t => t.age > adult && t.isAlive && t.sex == Sex.male).Count() * group);

            ageFemale.Add(Convert.ToInt32(TypeData.youngFemale),
                populate.Where(t => t.age <= young && t.isAlive && t.sex == Sex.female).Count() * group);
            ageFemale.Add(Convert.ToInt32(TypeData.middleFemale),
                populate.Where(t => t.age > young && t.age <= middle && t.isAlive && t.sex == Sex.female).Count() * group);
            ageFemale.Add(Convert.ToInt32(TypeData.adultFemale),
                populate.Where(t => t.age > middle && t.age <= adult && t.isAlive && t.sex == Sex.female).Count() * group);
            ageFemale.Add(Convert.ToInt32(TypeData.oldFemale),
                populate.Where(t => t.age > adult && t.isAlive && t.sex == Sex.female).Count() * group);

            data.Add(TypeData.general, general);
            data.Add(TypeData.generalMale, gmale);
            data.Add(TypeData.generalFemale, gfemale);
            data.Add(TypeData.ageMale, ageMale);
            data.Add(TypeData.ageFemale, ageFemale);
        }

        private void InitPerson(int count)
        {
            if (initAgeProbability == null)
            {
                FilesController fc = new FilesController();
                initAgeProbability = fc.GetInitProbability();
            }
            if (populate == null)
            {
                populate = new List<Person>();
            }
            populate.Clear();
            events = null;
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
            Sex sex = (StatRandom.IsEventHappened(birthMaleProbability) ? Sex.male : Sex.female);
            AddPerson(0, sex);
        }

        public void Death(Person sender)
        {
            sender.isAlive = false;
            sender.dateDeath = currentYear;
            // Отписываем
            events -= sender.NextYear;
            sender.birthEvent -= Birth;
            sender.deathEvent -= Death;
        }

        public Dictionary<int, int> GetData(TypeData type)
        {
            if (data.Count != 0)
            {
                return data[type];
            } else {
                throw new Exception("Нет данных");
            }
        }
    }
}
