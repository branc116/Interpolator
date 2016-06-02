using System.Windows.Forms;
using System.Drawing;

namespace Interpolator
{
    partial class tocka
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private Panel Panel_tocke;
        private CheckBox show_tocke;
        private Button dlt_tocke;
        private Label x_tocke , y_tocke , id_tocke ;
        private Label global_tocke ;
        private void InitializeComponent()
        {
            this.global_tocke = new System.Windows.Forms.Label();
            this.id_tocke = new System.Windows.Forms.Label();
            this.y_tocke = new System.Windows.Forms.Label();
            this.Panel_tocke = new System.Windows.Forms.Panel();
            this.show_tocke = new System.Windows.Forms.CheckBox();
            this.dlt_tocke = new System.Windows.Forms.Button();
            this.x_tocke = new System.Windows.Forms.Label();
            this.izbrisi_label = new System.Windows.Forms.Label();
            this.y_label = new System.Windows.Forms.Label();
            this.koristi_label = new System.Windows.Forms.Label();
            this.x_lable = new System.Windows.Forms.Label();
            this.id_lable = new System.Windows.Forms.Label();
            this.Panel_tocke.SuspendLayout();
            this.SuspendLayout();
            // 
            // global_tocke
            // 
            this.global_tocke.Location = new System.Drawing.Point(0, 0);
            this.global_tocke.Name = "global_tocke";
            this.global_tocke.Size = new System.Drawing.Size(0, 0);
            this.global_tocke.TabIndex = 22222;
            // 
            // id_tocke
            // 
            this.id_tocke.AutoSize = true;
            this.id_tocke.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.id_tocke.Location = new System.Drawing.Point(107, 61);
            this.id_tocke.Margin = new System.Windows.Forms.Padding(0);
            this.id_tocke.Name = "id_tocke";
            this.id_tocke.Size = new System.Drawing.Size(24, 22);
            this.id_tocke.TabIndex = 11111;
            this.id_tocke.Text = "id";
            // 
            // y_tocke
            // 
            this.y_tocke.AutoSize = true;
            this.y_tocke.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F);
            this.y_tocke.Location = new System.Drawing.Point(206, 57);
            this.y_tocke.Name = "y_tocke";
            this.y_tocke.Size = new System.Drawing.Size(19, 22);
            this.y_tocke.TabIndex = 66666;
            this.y_tocke.Text = "y";
            this.y_tocke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.y_tocke.Click += new System.EventHandler(this.OnClickCoordinates);
            // 
            // Panel_tocke
            // 
            this.Panel_tocke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_tocke.Controls.Add(this.y_tocke);
            this.Panel_tocke.Controls.Add(this.show_tocke);
            this.Panel_tocke.Controls.Add(this.dlt_tocke);
            this.Panel_tocke.Controls.Add(this.x_tocke);
            this.Panel_tocke.Controls.Add(this.id_tocke);
            this.Panel_tocke.Controls.Add(this.global_tocke);
            this.Panel_tocke.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_tocke.Location = new System.Drawing.Point(0, 0);
            this.Panel_tocke.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_tocke.Name = "Panel_tocke";
            this.Panel_tocke.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.Panel_tocke.Size = new System.Drawing.Size(344, 176);
            this.Panel_tocke.TabIndex = 10;
            // 
            // show_tocke
            // 
            this.show_tocke.AutoSize = true;
            this.show_tocke.Location = new System.Drawing.Point(253, 26);
            this.show_tocke.Margin = new System.Windows.Forms.Padding(0);
            this.show_tocke.Name = "show_tocke";
            this.show_tocke.Padding = new System.Windows.Forms.Padding(17, 4, 0, 0);
            this.show_tocke.Size = new System.Drawing.Size(32, 18);
            this.show_tocke.TabIndex = 44444;
            this.show_tocke.UseVisualStyleBackColor = true;
            this.show_tocke.Click += new System.EventHandler(this.OnClickShow);
            // 
            // dlt_tocke
            // 
            this.dlt_tocke.Image = global::Interpolator.Properties.Resources.dlt_img;
            this.dlt_tocke.Location = new System.Drawing.Point(229, 119);
            this.dlt_tocke.Margin = new System.Windows.Forms.Padding(0);
            this.dlt_tocke.Name = "dlt_tocke";
            this.dlt_tocke.Size = new System.Drawing.Size(23, 23);
            this.dlt_tocke.TabIndex = 55555;
            this.dlt_tocke.UseVisualStyleBackColor = true;
            this.dlt_tocke.Click += new System.EventHandler(this.OnClickDlt);
            // 
            // x_tocke
            // 
            this.x_tocke.AutoSize = true;
            this.x_tocke.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.x_tocke.Location = new System.Drawing.Point(150, 61);
            this.x_tocke.Name = "x_tocke";
            this.x_tocke.Size = new System.Drawing.Size(19, 22);
            this.x_tocke.TabIndex = 666666;
            this.x_tocke.Text = "x";
            this.x_tocke.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.x_tocke.Click += new System.EventHandler(this.OnClickCoordinates);
            // 
            // izbrisi_label
            // 
            this.izbrisi_label.AutoSize = true;
            this.izbrisi_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.izbrisi_label.Location = new System.Drawing.Point(278, 1);
            this.izbrisi_label.Name = "izbrisi_label";
            this.izbrisi_label.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.izbrisi_label.Size = new System.Drawing.Size(38, 20);
            this.izbrisi_label.TabIndex = 8;
            this.izbrisi_label.Text = "Izbriši";
            // 
            // y_label
            // 
            this.y_label.AutoSize = true;
            this.y_label.Location = new System.Drawing.Point(135, 1);
            this.y_label.Name = "y_label";
            this.y_label.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.y_label.Size = new System.Drawing.Size(14, 16);
            this.y_label.TabIndex = 6;
            this.y_label.Text = "Y";
            // 
            // koristi_label
            // 
            this.koristi_label.AutoSize = true;
            this.koristi_label.Location = new System.Drawing.Point(235, 1);
            this.koristi_label.Name = "koristi_label";
            this.koristi_label.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.koristi_label.Size = new System.Drawing.Size(35, 16);
            this.koristi_label.TabIndex = 9;
            this.koristi_label.Text = "koristi";
            // 
            // x_lable
            // 
            this.x_lable.AutoSize = true;
            this.x_lable.Location = new System.Drawing.Point(35, 1);
            this.x_lable.Name = "x_lable";
            this.x_lable.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.x_lable.Size = new System.Drawing.Size(14, 16);
            this.x_lable.TabIndex = 10;
            this.x_lable.Text = "X";
            // 
            // id_lable
            // 
            this.id_lable.AutoSize = true;
            this.id_lable.Location = new System.Drawing.Point(4, 1);
            this.id_lable.Name = "id_lable";
            this.id_lable.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.id_lable.Size = new System.Drawing.Size(19, 16);
            this.id_lable.TabIndex = 11;
            this.id_lable.Text = "ID";
            // 
            // tocka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel_tocke);
            this.Name = "tocka";
            this.Size = new System.Drawing.Size(344, 281);
            this.Panel_tocke.ResumeLayout(false);
            this.Panel_tocke.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private Label izbrisi_label;
        private Label y_label;
        private Label koristi_label;
        private Label x_lable;
        private Label id_lable;
    }
}
