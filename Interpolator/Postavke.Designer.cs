namespace Interpolator
{


    partial class Postavke
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
            this.Hide();
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Postavke));
            this.Docke = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.Error = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grafiks = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Docke.SuspendLayout();
            this.General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.Grafiks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Docke
            // 
            this.Docke.Controls.Add(this.General);
            this.Docke.Controls.Add(this.Grafiks);
            this.Docke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Docke.ItemSize = new System.Drawing.Size(55, 15);
            this.Docke.Location = new System.Drawing.Point(0, 0);
            this.Docke.Margin = new System.Windows.Forms.Padding(0);
            this.Docke.Name = "Docke";
            this.Docke.SelectedIndex = 0;
            this.Docke.Size = new System.Drawing.Size(273, 267);
            this.Docke.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.Docke.TabIndex = 0;
            // 
            // General
            // 
            this.General.BackColor = System.Drawing.Color.Wheat;
            this.General.Controls.Add(this.Error);
            this.General.Controls.Add(this.label2);
            this.General.Controls.Add(this.textBox1);
            this.General.Controls.Add(this.label1);
            this.General.Location = new System.Drawing.Point(4, 19);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(265, 244);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            // 
            // Error
            // 
            this.Error.ErrorImage = global::Interpolator.Properties.Resources.Error;
            this.Error.Image = global::Interpolator.Properties.Resources.Error1;
            this.Error.Location = new System.Drawing.Point(196, 10);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(16, 16);
            this.Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Error.TabIndex = 5;
            this.Error.TabStop = false;
            this.Error.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Decimals.";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(89, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(25, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "2";
            this.textBox1.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Round on";
            // 
            // Grafiks
            // 
            this.Grafiks.BackColor = System.Drawing.Color.Wheat;
            this.Grafiks.Controls.Add(this.label4);
            this.Grafiks.Controls.Add(this.trackBar1);
            this.Grafiks.Location = new System.Drawing.Point(4, 19);
            this.Grafiks.Name = "Grafiks";
            this.Grafiks.Padding = new System.Windows.Forms.Padding(3);
            this.Grafiks.Size = new System.Drawing.Size(265, 244);
            this.Grafiks.TabIndex = 1;
            this.Grafiks.Text = "Graphics";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Wheat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Rezolucija crte";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FloralWhite;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(11, 23);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(262, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 2;
            this.trackBar1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // Postavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(273, 267);
            this.Controls.Add(this.Docke);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Postavke";
            this.Text = "Options";
            this.Docke.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.Grafiks.ResumeLayout(false);
            this.Grafiks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Docke;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Grafiks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox Error;
    }
}