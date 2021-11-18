using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemographicModel
{
    class Engine
    {
        public delegate void PersonHandler();
        public event PersonHandler events;
        private int currentYear { get; set; }
        public void NextYear()
        {
            currentYear++;
            events?.Invoke();

        }
    }

    
}
