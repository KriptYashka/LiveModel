using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemographicModel
{

    public enum Generation
    {
        young = 18,
        middle = 45,
        adult = 65,
    }
    public enum Sex
    {
        male = 0,
        female = 1,
    }

    public enum TypeData
    {
        general = 0,
        generalMale = 1,
        generalFemale = 2,
        youngMale = 3,
        middleMale = 4,
        adultMale = 5,
        oldMale = 6,
        youngFemale = 7,
        middleFemale = 8,
        adultFemale = 9,
        oldFemale = 10,
        ageMale = 11,
        ageFemale = 12,
    }
}
