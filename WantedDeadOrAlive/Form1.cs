using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DemographicModel;
using DemographicFileOperations;

namespace WantedDeadOrAlive
{
    public partial class Form1 : Form
    {
        private Engine engine;
        private FilesController fc;
        public Form1()
        {
            InitializeComponent();
            BarExample();
            engine = new Engine();
            fc = new FilesController();
            engine.initAgeProbability = fc.GetInitProbability();
            engine.deathProbability = fc.GetDeathRules();
            engine.ModelTime(2000, 2021, 10000000);
        }

        public void BarExample()
        {
            this.chart1.Series.Clear();

            // Data arrays
            string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
            int[] pointsArray = { 2, 1, 7, 5 };

            // Set palette
            this.chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.chart1.Titles.Add("Animals");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

    }
}
