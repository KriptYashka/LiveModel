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
            progressBar1.Value = Math.Min(procentage, 100);
        }

        public void DrawGeneral(Dictionary<int, int> general)
        {
            this.chartGeneral.Series.Clear();
            this.chartGeneral.Titles.Clear();
            this.chartGeneral.Titles.Add("General Population");
            Series series = this.chartGeneral.Series.Add("General Population");
            this.chartGeneral.ChartAreas.First().AxisY.Minimum = general.Values.Min() * 0.8;
            this.chartGeneral.ChartAreas.First().AxisY.Maximum = general.Values.Max() * 1.1;
            this.chartGeneral.ChartAreas.First().AxisX.Minimum = general.Keys.Min();
            this.chartGeneral.ChartAreas.First().AxisX.Maximum = general.Keys.Max() + ((general.Keys.Max() - general.Keys.Min()) % 5 == 0 ? 0 : 5 - (general.Keys.Max() - general.Keys.Min()) % 5);
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
            this.chartSex.ChartAreas.First().AxisY.Minimum = male.Values.Min() * 0.8;
            this.chartSex.ChartAreas.First().AxisY.Maximum = male.Values.Max() * 1.1;
            this.chartSex.ChartAreas.First().AxisX.Minimum = male.Keys.Min();
            this.chartSex.ChartAreas.First().AxisX.Maximum = male.Keys.Max() + ((male.Keys.Max() - male.Keys.Min()) % 5 == 0 ? 0 : 5 - (male.Keys.Max() - male.Keys.Min()) % 5);

            seriesFemale.ChartType = SeriesChartType.Spline;

            foreach (int year in male.Keys)
            {
                seriesMale.Points.AddXY(year, male[year]);
                seriesFemale.Points.AddXY(year, female[year]);
            }
        }

        public void DrawBarMale(Dictionary<int, int> data)
        {
            this.chartMale.Series.Clear();
            this.chartMale.Titles.Clear();
            this.chartMale.Titles.Add("Male ages");
            this.chartMale.ChartAreas.First().AxisY.Maximum = data.Values.Max() * 1.1;
            Series series;
            series = this.chartMale.Series.Add("Young");
            series.Points.Add(data[Convert.ToInt32(TypeData.youngMale)]);
            series = this.chartMale.Series.Add("Middle");
            series.Points.Add(data[Convert.ToInt32(TypeData.middleMale)]);
            series = this.chartMale.Series.Add("Adult");
            series.Points.Add(data[Convert.ToInt32(TypeData.adultMale)]);
            series = this.chartMale.Series.Add("Old");
            series.Points.Add(data[Convert.ToInt32(TypeData.oldMale)]);
        }

        public void DrawBarFemale(Dictionary<int, int> data)
        {
            this.chartFemale.Series.Clear();
            this.chartFemale.Titles.Clear();
            this.chartFemale.Titles.Add("Female ages");
            this.chartFemale.ChartAreas.First().AxisY.Maximum = data.Values.Max() * 1.1;
            Series series;
            series = this.chartFemale.Series.Add("Young");
            series.Points.Add(data[Convert.ToInt32(TypeData.youngFemale)]);
            series = this.chartFemale.Series.Add("Middle");
            series.Points.Add(data[Convert.ToInt32(TypeData.middleFemale)]);
            series = this.chartFemale.Series.Add("Adult");
            series.Points.Add(data[Convert.ToInt32(TypeData.adultFemale)]);
            series = this.chartFemale.Series.Add("Old");
            series.Points.Add(data[Convert.ToInt32(TypeData.oldFemale)]);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(textBoxFromYear.Text);
            int to = Convert.ToInt32(textBoxToYear.Text);
            if (to < from)
            {
                MessageBox.Show("Введены некорректные значения.");
                return;
            }
            int population = Convert.ToInt32(textBoxPopulate.Text);
            try
            {
                engine.ModelTime(from, to, population);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            DrawGeneral(engine.GetData(TypeData.general));
            DrawSex(engine.GetData(TypeData.generalMale), engine.GetData(TypeData.generalFemale));
            DrawBarMale(engine.GetData(TypeData.ageMale));
            DrawBarFemale(engine.GetData(TypeData.ageFemale));
        }
    }
}
