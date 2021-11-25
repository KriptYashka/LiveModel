
namespace WantedDeadOrAlive
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGeneral = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxFromYear = new System.Windows.Forms.TextBox();
            this.textBoxToYear = new System.Windows.Forms.TextBox();
            this.chartSex = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFemale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxPopulate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFemale)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGeneral
            // 
            this.chartGeneral.BackColor = System.Drawing.Color.Silver;
            this.chartGeneral.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.Name = "ChartArea1";
            this.chartGeneral.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGeneral.Legends.Add(legend1);
            this.chartGeneral.Location = new System.Drawing.Point(12, 158);
            this.chartGeneral.Name = "chartGeneral";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGeneral.Series.Add(series1);
            this.chartGeneral.Size = new System.Drawing.Size(639, 300);
            this.chartGeneral.TabIndex = 0;
            this.chartGeneral.Text = "chart1";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(228, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 86);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Model";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxFromYear
            // 
            this.textBoxFromYear.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxFromYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFromYear.Location = new System.Drawing.Point(14, 32);
            this.textBoxFromYear.Name = "textBoxFromYear";
            this.textBoxFromYear.Size = new System.Drawing.Size(100, 29);
            this.textBoxFromYear.TabIndex = 2;
            this.textBoxFromYear.Text = "1971";
            this.textBoxFromYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxToYear
            // 
            this.textBoxToYear.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxToYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxToYear.Location = new System.Drawing.Point(120, 32);
            this.textBoxToYear.Name = "textBoxToYear";
            this.textBoxToYear.Size = new System.Drawing.Size(100, 29);
            this.textBoxToYear.TabIndex = 3;
            this.textBoxToYear.Text = "2021";
            this.textBoxToYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chartSex
            // 
            this.chartSex.BackColor = System.Drawing.Color.Silver;
            this.chartSex.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.Name = "ChartArea1";
            this.chartSex.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSex.Legends.Add(legend2);
            this.chartSex.Location = new System.Drawing.Point(12, 464);
            this.chartSex.Name = "chartSex";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSex.Series.Add(series2);
            this.chartSex.Size = new System.Drawing.Size(639, 300);
            this.chartSex.TabIndex = 4;
            this.chartSex.Text = "chart1";
            // 
            // chartMale
            // 
            this.chartMale.BackColor = System.Drawing.Color.Silver;
            this.chartMale.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea3.Name = "ChartArea1";
            this.chartMale.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMale.Legends.Add(legend3);
            this.chartMale.Location = new System.Drawing.Point(657, 158);
            this.chartMale.Name = "chartMale";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMale.Series.Add(series3);
            this.chartMale.Size = new System.Drawing.Size(429, 300);
            this.chartMale.TabIndex = 5;
            this.chartMale.Text = "chart2";
            // 
            // chartFemale
            // 
            this.chartFemale.BackColor = System.Drawing.Color.Silver;
            this.chartFemale.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.Name = "ChartArea1";
            this.chartFemale.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartFemale.Legends.Add(legend4);
            this.chartFemale.Location = new System.Drawing.Point(657, 464);
            this.chartFemale.Name = "chartFemale";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartFemale.Series.Add(series4);
            this.chartFemale.Size = new System.Drawing.Size(429, 300);
            this.chartFemale.TabIndex = 6;
            this.chartFemale.Text = "chart3";
            // 
            // textBoxPopulate
            // 
            this.textBoxPopulate.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxPopulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPopulate.Location = new System.Drawing.Point(14, 89);
            this.textBoxPopulate.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxPopulate.Name = "textBoxPopulate";
            this.textBoxPopulate.Size = new System.Drawing.Size(206, 29);
            this.textBoxPopulate.TabIndex = 7;
            this.textBoxPopulate.Text = "1000000";
            this.textBoxPopulate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Population";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(116, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "End Year";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 126);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1074, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1214, 799);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPopulate);
            this.Controls.Add(this.chartFemale);
            this.Controls.Add(this.chartMale);
            this.Controls.Add(this.chartSex);
            this.Controls.Add(this.textBoxToYear);
            this.Controls.Add(this.textBoxFromYear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chartGeneral);
            this.Name = "Form1";
            this.Text = "KriptYashka";
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFemale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGeneral;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxFromYear;
        private System.Windows.Forms.TextBox textBoxToYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSex;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFemale;
        private System.Windows.Forms.TextBox textBoxPopulate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

