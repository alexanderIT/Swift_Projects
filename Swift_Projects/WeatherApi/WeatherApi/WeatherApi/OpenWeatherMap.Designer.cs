namespace WeatherApi
{
    partial class OpenWeatherMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTempMin = new System.Windows.Forms.Label();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.picCountry = new System.Windows.Forms.PictureBox();
            this.picWeather = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCountries
            // 
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(75, 9);
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(154, 24);
            this.cmbCountries.TabIndex = 0;
            this.cmbCountries.SelectedIndexChanged += new System.EventHandler(this.cmbCountries_SelectedIndexChanged);
            // 
            // cmbCities
            // 
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(75, 39);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(154, 24);
            this.cmbCities.TabIndex = 0;
            this.cmbCities.SelectedIndexChanged += new System.EventHandler(this.cmbCities_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Country";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "City";
            // 
            // lblTempMin
            // 
            this.lblTempMin.AutoSize = true;
            this.lblTempMin.Location = new System.Drawing.Point(12, 85);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(80, 17);
            this.lblTempMin.TabIndex = 3;
            this.lblTempMin.Text = "lblTempMin";
            // 
            // lblTempMax
            // 
            this.lblTempMax.AutoSize = true;
            this.lblTempMax.Location = new System.Drawing.Point(12, 102);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(83, 17);
            this.lblTempMax.TabIndex = 4;
            this.lblTempMax.Text = "lblTempMax";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 119);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(93, 17);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "lblDescription";
            // 
            // picCountry
            // 
            this.picCountry.Location = new System.Drawing.Point(235, 9);
            this.picCountry.Name = "picCountry";
            this.picCountry.Size = new System.Drawing.Size(104, 54);
            this.picCountry.TabIndex = 8;
            this.picCountry.TabStop = false;
            // 
            // picWeather
            // 
            this.picWeather.Location = new System.Drawing.Point(164, 85);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(175, 94);
            this.picWeather.TabIndex = 8;
            this.picWeather.TabStop = false;
            // 
            // OpenWeatherMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 213);
            this.Controls.Add(this.picWeather);
            this.Controls.Add(this.picCountry);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTempMax);
            this.Controls.Add(this.lblTempMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCities);
            this.Controls.Add(this.cmbCountries);
            this.Name = "OpenWeatherMap";
            this.Text = "OpenWeatherMap";
            this.Load += new System.EventHandler(this.OpenWeatherMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCountries;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTempMin;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picCountry;
        private System.Windows.Forms.PictureBox picWeather;

    }
}