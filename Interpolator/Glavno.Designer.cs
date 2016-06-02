using System;

namespace Interpolator
{

    partial class Form1
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
            //th.Suspend();  
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Datoteke = new System.Windows.Forms.ToolStripDropDownButton();
            this.Make = new System.Windows.Forms.ToolStripMenuItem();
            this.datotekuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funkcijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_file = new System.Windows.Forms.ToolStripMenuItem();
            this.spremi = new System.Windows.Forms.ToolStripMenuItem();
            this.spremiKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Zatvori = new System.Windows.Forms.ToolStripMenuItem();
            this.Pogled = new System.Windows.Forms.ToolStripDropDownButton();
            this.Odabir = new System.Windows.Forms.ToolStripMenuItem();
            this.Postavke = new System.Windows.Forms.ToolStripDropDownButton();
            this.Postavke_box = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.Pomoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Osvjezi = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Izaberi_boju = new System.Windows.Forms.ColorDialog();
            this.Save = new System.Windows.Forms.SaveFileDialog();
            this.Open = new System.Windows.Forms.OpenFileDialog();
            this.worker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Datoteke
            // 
            this.Datoteke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Datoteke.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Datoteke.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Make,
            this.open_file,
            this.spremi,
            this.spremiKaoToolStripMenuItem,
            this.toolStripSeparator3,
            this.Zatvori});
            this.Datoteke.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Datoteke.Name = "Datoteke";
            this.Datoteke.Size = new System.Drawing.Size(38, 19);
            this.Datoteke.Text = "File";
            this.Datoteke.ToolTipText = "Datoteke";
            // 
            // Make
            // 
            this.Make.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekuToolStripMenuItem,
            this.funkcijuToolStripMenuItem});
            this.Make.Name = "Make";
            this.Make.Size = new System.Drawing.Size(152, 22);
            this.Make.Text = "New";
            // 
            // datotekuToolStripMenuItem
            // 
            this.datotekuToolStripMenuItem.Name = "datotekuToolStripMenuItem";
            this.datotekuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.datotekuToolStripMenuItem.Text = "File";
            this.datotekuToolStripMenuItem.Click += new System.EventHandler(this.napravi_novu_datoteku);
            // 
            // funkcijuToolStripMenuItem
            // 
            this.funkcijuToolStripMenuItem.Name = "funkcijuToolStripMenuItem";
            this.funkcijuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.funkcijuToolStripMenuItem.Text = "Function";
            this.funkcijuToolStripMenuItem.Click += new System.EventHandler(this.dodajbut);
            // 
            // open_file
            // 
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(152, 22);
            this.open_file.Text = "Open";
            this.open_file.Click += new System.EventHandler(this.otvori_dat);
            // 
            // spremi
            // 
            this.spremi.Name = "spremi";
            this.spremi.Size = new System.Drawing.Size(152, 22);
            this.spremi.Text = "Save";
            this.spremi.Click += new System.EventHandler(this.spremi_datoteku);
            // 
            // spremiKaoToolStripMenuItem
            // 
            this.spremiKaoToolStripMenuItem.Name = "spremiKaoToolStripMenuItem";
            this.spremiKaoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spremiKaoToolStripMenuItem.Text = "Save as";
            this.spremiKaoToolStripMenuItem.Click += new System.EventHandler(this.spremi_datoteku);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // Zatvori
            // 
            this.Zatvori.Name = "Zatvori";
            this.Zatvori.Size = new System.Drawing.Size(152, 22);
            this.Zatvori.Text = "Exit";
            this.Zatvori.Click += new System.EventHandler(this.exit);
            // 
            // Pogled
            // 
            this.Pogled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Pogled.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Odabir});
            this.Pogled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pogled.Name = "Pogled";
            this.Pogled.Size = new System.Drawing.Size(45, 19);
            this.Pogled.Text = "View";
            this.Pogled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Odabir
            // 
            this.Odabir.Name = "Odabir";
            this.Odabir.Size = new System.Drawing.Size(158, 22);
            this.Odabir.Text = "Show Functions";
            this.Odabir.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Postavke
            // 
            this.Postavke.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Postavke.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Postavke_box});
            this.Postavke.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Postavke.Name = "Postavke";
            this.Postavke.Size = new System.Drawing.Size(58, 19);
            this.Postavke.Text = "Setings";
            // 
            // Postavke_box
            // 
            this.Postavke_box.Name = "Postavke_box";
            this.Postavke_box.Size = new System.Drawing.Size(166, 22);
            this.Postavke_box.Text = "Setings (It\'s shit..)";
            this.Postavke_box.Click += new System.EventHandler(this.otvori_postavke);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pomoc,
            this.toolStripSeparator2,
            this.About});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 19);
            this.toolStripDropDownButton1.Text = "Help";
            // 
            // Pomoc
            // 
            this.Pomoc.Name = "Pomoc";
            this.Pomoc.Size = new System.Drawing.Size(320, 22);
            this.Pomoc.Text = "Help (in Croatian, can\'t be botterd to translate)";
            this.Pomoc.Click += new System.EventHandler(this.OnClickPomoc);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(317, 6);
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(320, 22);
            this.About.Text = "About";
            this.About.Click += new System.EventHandler(this.OnClickAbout);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.DarkKhaki;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Osvjezi,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(722, 25);
            this.toolStrip2.TabIndex = 10;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Osvjezi
            // 
            this.Osvjezi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Osvjezi.Image = global::Interpolator.Properties.Resources.refresh_img;
            this.Osvjezi.ImageTransparentColor = System.Drawing.Color.White;
            this.Osvjezi.Name = "Osvjezi";
            this.Osvjezi.Size = new System.Drawing.Size(23, 22);
            this.Osvjezi.Text = "toolStripButton2";
            this.Osvjezi.ToolTipText = "Refresh";
            this.Osvjezi.Click += new System.EventHandler(this.otvori_dat);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Interpolator.Properties.Resources.dodaj_img;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "dodaj";
            this.toolStripButton1.ToolTipText = "Add function";
            this.toolStripButton1.Click += new System.EventHandler(this.dodajbut);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Interpolator.Properties.Resources.prikazi_grafiku;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Show functions";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.DarkKhaki;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Datoteke,
            this.Pogled,
            this.Postavke,
            this.toolStripDropDownButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(722, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Izaberi_boju
            // 
            this.Izaberi_boju.AnyColor = true;
            this.Izaberi_boju.Color = System.Drawing.Color.Yellow;
            // 
            // Save
            // 
            this.Save.Title = "Napravi datoteku";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(722, 378);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pregled točki i funkcija";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }





        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox Input_x;
        public System.Windows.Forms.TextBox Input_y;
        public System.Windows.Forms.Label func_label;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton Datoteke;
        private System.Windows.Forms.ToolStripMenuItem open_file;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton Pogled;
        private System.Windows.Forms.ToolStripMenuItem Odabir;
        private System.Windows.Forms.ToolStripDropDownButton Postavke;
        private System.Windows.Forms.ToolStripMenuItem Postavke_box;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem Pomoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ColorDialog Izaberi_boju;
        private System.Windows.Forms.SaveFileDialog Save;
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.ToolStripMenuItem Make;
        private System.Windows.Forms.ToolStripButton Osvjezi;
        private System.Windows.Forms.ToolStripMenuItem Zatvori;
        private System.ComponentModel.BackgroundWorker worker1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem datotekuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funkcijuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spremi;
        private System.Windows.Forms.ToolStripMenuItem spremiKaoToolStripMenuItem;
    }
}
