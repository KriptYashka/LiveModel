using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DemographicFileOperations
{
    public class FilesController
    {
        private const string pathInit = "../../../InitialAge.csv";
        private const string pathDeath = "../../../DeathRules.csv";

        public Dictionary<int, double> GetInitProbability(string path = pathInit)
        {
            Dictionary<int, double> ageProbability = new Dictionary<int, double>();
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length != 2) continue;
                int age;
                double probability;
                bool isInt = Int32.TryParse(data[0], out age);
                bool isDouble = Double.TryParse(data[1].Replace('.', ','), out probability);
                if (isDouble && isInt)
                {
                    ageProbability.Add(age, probability);
                }
            }
            return ageProbability;
        }

        public List<List<double>> GetDeathRules(string path = pathDeath)
        {
            List<List<double>> deathData = new List<List<double>>();
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length != 4) continue;
                int age_start, age_end;
                double probability_male, probability_female;
                bool isInt1 = Int32.TryParse(data[0], out age_start);
                bool isInt2 = Int32.TryParse(data[1], out age_end);
                bool isDouble1 = Double.TryParse(data[2].Replace('.', ','), out probability_male);
                bool isDouble2 = Double.TryParse(data[3].Replace('.', ','), out probability_female);
                if (isInt1 && isInt2 && isDouble1 && isDouble2)
                {
                    deathData.Add(new List<double>() { age_start, age_end, probability_male, probability_female });
                }
            }
            if (deathData.Count == 0) 
                throw new Exception("Некорректный файл");
            return deathData;
        }
    }
}
