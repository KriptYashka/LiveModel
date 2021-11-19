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
            engine = new Engine();
            engine.loading += SetBar;
            fc = new FilesController();
            engine.initAgeProbability = fc.GetInitProbability();
        }

        public void SetBar(int procentage)
        {
            progressBar1.Value = procentage;
        }

        public void DrawGeneral(Dictionary<int, int> general)
        {
            this.chartGeneral.Series.Clear();
            this.chartGeneral.Titles.Clear();
            this.chartGeneral.Titles.Add("General Population");
            Series series = this.chartGeneral.Series.Add("General Population");
            series.BorderWidth = 3;
            series.ChartType = SeriesChartType.Spline;

            foreach (int year in general.Keys)
            {
                series.Points.AddXY(year, general[year]);
            }
        }

        public void DrawSex(Dictionary<int, int> male, Dictionary<int, int> female)
        {
            this.chartSex.Series.Clear();
            this.chartSex.Titles.Clear();
            this.chartSex.Titles.Add("General Population");
            Series seriesMale = this.chartSex.Series.Add("General male population");
            seriesMale.BorderWidth = 2;
            seriesMale.ChartType = SeriesChartType.Spline;
            Series seriesFemale = this.chartSex.Series.Add("General female population");
            seriesFemale.Color = Color.Red;
            seriesFemale.BorderWidth = 2;
            seriesFemale.ChartType = SeriesChartType.Spline;

            foreach (int year in male.Keys)
            {
                seriesMale.Points.AddXY(year, male[year]);
                seriesFemale.Points.AddXY(year, female[year]);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(textBoxFromYear.Text);
            int to = Convert.ToInt32(textBoxToYear.Text);
            int population = Convert.ToInt32(textBoxPopulate.Text);
            engine.ModelTime(from, to, population);
            DrawGeneral(engine.GetData(TypeData.general));
            DrawSex(engine.GetData(TypeData.generalMale), engine.GetData(TypeData.generalFemale));
        }
    }
}
