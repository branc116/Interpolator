using System.Windows.Forms;
using System.Drawing;
namespace Interpolator
{
    partial class funkcija
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(funkcija));
            this.points = new System.Windows.Forms.GroupBox();
            this.MyTable = new System.Windows.Forms.TableLayoutPanel();
            this.izbrisi_label = new System.Windows.Forms.Label();
            this.y_label = new System.Windows.Forms.Label();
            this.koristi_label = new System.Windows.Forms.Label();
            this.x_lable = new System.Windows.Forms.Label();
            this.id_lable = new System.Windows.Forms.Label();
            this.func_label = new System.Windows.Forms.Label();
            this.global_id_label = new System.Windows.Forms.Label();
            this.Input_x = new System.Windows.Forms.TextBox();
            this.Input_y = new System.Windows.Forms.TextBox();
            this.dodaj_button = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.Properties = new System.Windows.Forms.ToolStrip();
            this.Copy_button = new System.Windows.Forms.ToolStripButton();
            this.mode = new System.Windows.Forms.ToolStripButton();
            this.Color = new System.Windows.Forms.ToolStripButton();
            this.Izgled = new System.Windows.Forms.ToolStrip();
            this.x_but = new System.Windows.Forms.ToolStripButton();
            this.maxy = new System.Windows.Forms.ToolStripButton();
            this.miny = new System.Windows.Forms.ToolStripButton();
            this.Naslov = new System.Windows.Forms.ToolStrip();
            this.Name_of_func = new System.Windows.Forms.ToolStripButton();
            this.ErrorBox = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.points.SuspendLayout();
            this.MyTable.SuspendLayout();
            this.Panel.SuspendLayout();
            this.Properties.SuspendLayout();
            this.Izgled.SuspendLayout();
            this.Naslov.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // points
            // 
            this.points.AccessibleName = "1";
            this.points.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.points.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.points.BackColor = System.Drawing.Color.LemonChiffon;
            this.points.Controls.Add(this.MyTable);
            this.points.Location = new System.Drawing.Point(8, 107);
            this.points.Margin = new System.Windows.Forms.Padding(0);
            this.points.Name = "points";
            this.points.Padding = new System.Windows.Forms.Padding(0);
            this.points.Size = new System.Drawing.Size(324, 181);
            this.points.TabIndex = 0;
            this.points.TabStop = false;
            this.points.Text = "Points";
            // 
            // MyTable
            // 
            this.MyTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyTable.AutoScroll = true;
            this.MyTable.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.MyTable.AutoSize = true;
            this.MyTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MyTable.CausesValidation = false;
            this.MyTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.MyTable.ColumnCount = 5;
            this.MyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.MyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.MyTable.Controls.Add(this.izbrisi_label, 4, 0);
            this.MyTable.Controls.Add(this.y_label, 2, 0);
            this.MyTable.Controls.Add(this.koristi_label, 3, 0);
            this.MyTable.Controls.Add(this.x_lable, 1, 0);
            this.MyTable.Controls.Add(this.id_lable, 0, 0);
            this.MyTable.Location = new System.Drawing.Point(0, 16);
            this.MyTable.Margin = new System.Windows.Forms.Padding(0);
            this.MyTable.Name = "MyTable";
            this.MyTable.RowCount = 1;
            this.MyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.MyTable.Size = new System.Drawing.Size(320, 31);
            this.MyTable.TabIndex = 12;
            // 
            // izbrisi_label
            // 
            this.izbrisi_label.AutoSize = true;
            this.izbrisi_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.izbrisi_label.Location = new System.Drawing.Point(268, 1);
            this.izbrisi_label.Name = "izbrisi_label";
            this.izbrisi_label.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.izbrisi_label.Size = new System.Drawing.Size(48, 29);
            this.izbrisi_label.TabIndex = 8;
            this.izbrisi_label.Text = "Delete";
            // 
            // y_label
            // 
            this.y_label.AutoSize = true;
            this.y_label.Location = new System.Drawing.Point(130, 1);
            this.y_label.Name = "y_label";
            this.y_label.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.y_label.Size = new System.Drawing.Size(14, 16);
            this.y_label.TabIndex = 6;
            this.y_label.Text = "Y";
            // 
            // koristi_label
            // 
            this.koristi_label.AutoSize = true;
            this.koristi_label.Location = new System.Drawing.Point(225, 1);
            this.koristi_label.Name = "koristi_label";
            this.koristi_label.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.koristi_label.Size = new System.Drawing.Size(27, 16);
            this.koristi_label.TabIndex = 9;
            this.koristi_label.Text = "Use";
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
            // func_label
            // 
            this.func_label.AutoSize = true;
            this.func_label.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.func_label.Location = new System.Drawing.Point(5, 85);
            this.func_label.Name = "func_label";
            this.func_label.Size = new System.Drawing.Size(67, 20);
            this.func_label.TabIndex = 1;
            this.func_label.Text = "f(x)=NULL";
            // 
            // global_id_label
            // 
            this.global_id_label.Location = new System.Drawing.Point(0, 0);
            this.global_id_label.Name = "global_id_label";
            this.global_id_label.Size = new System.Drawing.Size(0, 0);
            this.global_id_label.TabIndex = 99;
            this.global_id_label.Text = "0";
            // 
            // Input_x
            // 
            this.Input_x.AcceptsReturn = true;
            this.Input_x.BackColor = System.Drawing.Color.Wheat;
            this.Input_x.Location = new System.Drawing.Point(8, 56);
            this.Input_x.Margin = new System.Windows.Forms.Padding(0);
            this.Input_x.Name = "Input_x";
            this.Input_x.Size = new System.Drawing.Size(45, 20);
            this.Input_x.TabIndex = 2;
            this.Input_x.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.Input_x.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // Input_y
            // 
            this.Input_y.BackColor = System.Drawing.Color.Wheat;
            this.Input_y.Location = new System.Drawing.Point(53, 56);
            this.Input_y.Margin = new System.Windows.Forms.Padding(0);
            this.Input_y.MaxLength = 10;
            this.Input_y.Name = "Input_y";
            this.Input_y.Size = new System.Drawing.Size(45, 20);
            this.Input_y.TabIndex = 3;
            this.Input_y.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.Input_y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // dodaj_button
            // 
            this.dodaj_button.Image = global::Interpolator.Properties.Resources.dodaj_img;
            this.dodaj_button.Location = new System.Drawing.Point(101, 56);
            this.dodaj_button.Name = "dodaj_button";
            this.dodaj_button.Size = new System.Drawing.Size(25, 25);
            this.dodaj_button.TabIndex = 4;
            this.dodaj_button.UseVisualStyleBackColor = true;
            this.dodaj_button.Click += new System.EventHandler(this.OnClickDodaj);
            // 
            // Panel
            // 
            this.Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel.BackColor = System.Drawing.Color.LemonChiffon;
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Controls.Add(this.points);
            this.Panel.Controls.Add(this.Properties);
            this.Panel.Controls.Add(this.func_label);
            this.Panel.Controls.Add(this.Izgled);
            this.Panel.Controls.Add(this.Input_x);
            this.Panel.Controls.Add(this.dodaj_button);
            this.Panel.Controls.Add(this.Input_y);
            this.Panel.Controls.Add(this.global_id_label);
            this.Panel.Controls.Add(this.Naslov);
            this.Panel.Controls.Add(this.ErrorBox);
            this.Panel.Location = new System.Drawing.Point(21, 36);
            this.Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Panel.MinimumSize = new System.Drawing.Size(203, 172);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(346, 289);
            this.Panel.TabIndex = 0;
            this.Panel.Click += new System.EventHandler(this.OnClickTakeFocus);
            this.Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMoveScale);
            // 
            // Properties
            // 
            this.Properties.BackColor = System.Drawing.Color.DarkKhaki;
            this.Properties.GripMargin = new System.Windows.Forms.Padding(0);
            this.Properties.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Properties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy_button,
            this.mode,
            this.Color});
            this.Properties.Location = new System.Drawing.Point(0, 22);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(344, 25);
            this.Properties.TabIndex = 104;
            this.Properties.Text = "Postavke";
            this.Properties.Click += new System.EventHandler(this.OnClickTakeFocus);
            // 
            // Copy_button
            // 
            this.Copy_button.AutoSize = false;
            this.Copy_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy_button.Image = global::Interpolator.Properties.Resources.copy;
            this.Copy_button.ImageTransparentColor = System.Drawing.Color.White;
            this.Copy_button.Margin = new System.Windows.Forms.Padding(0);
            this.Copy_button.Name = "Copy_button";
            this.Copy_button.Size = new System.Drawing.Size(22, 22);
            this.Copy_button.Text = "Kopiraj";
            this.Copy_button.ToolTipText = "Copy function";
            this.Copy_button.Click += new System.EventHandler(this.OnCopyToClipboard);
            // 
            // mode
            // 
            this.mode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mode.Image = ((System.Drawing.Image)(resources.GetObject("mode.Image")));
            this.mode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(27, 22);
            this.mode.Text = "Sin";
            this.mode.ToolTipText = "Sine or Polinomal interpolation";
            this.mode.Click += new System.EventHandler(this.OnClickCngMode);
            // 
            // Color
            // 
            this.Color.AutoSize = false;
            this.Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.Color.Image = ((System.Drawing.Image)(resources.GetObject("Color.Image")));
            this.Color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(30, 22);
            this.Color.Text = "Boja";
            this.Color.ToolTipText = "Color of function on graph";
            this.Color.Click += new System.EventHandler(this.OnClickPaint);
            // 
            // Izgled
            // 
            this.Izgled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Izgled.BackColor = System.Drawing.Color.DarkKhaki;
            this.Izgled.Dock = System.Windows.Forms.DockStyle.None;
            this.Izgled.GripMargin = new System.Windows.Forms.Padding(0);
            this.Izgled.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.Izgled.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x_but,
            this.maxy,
            this.miny});
            this.Izgled.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Izgled.Location = new System.Drawing.Point(278, 0);
            this.Izgled.Name = "Izgled";
            this.Izgled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Izgled.Size = new System.Drawing.Size(67, 22);
            this.Izgled.Stretch = true;
            this.Izgled.TabIndex = 103;
            this.Izgled.Text = "toolStrip1";
            // 
            // x_but
            // 
            this.x_but.AutoSize = false;
            this.x_but.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.x_but.Image = global::Interpolator.Properties.Resources.dlt_img;
            this.x_but.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.x_but.ImageTransparentColor = System.Drawing.Color.White;
            this.x_but.Margin = new System.Windows.Forms.Padding(0);
            this.x_but.Name = "x_but";
            this.x_but.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.x_but.Size = new System.Drawing.Size(22, 22);
            this.x_but.Text = "Zatvori";
            this.x_but.Click += new System.EventHandler(this.OnClickClose);
            // 
            // maxy
            // 
            this.maxy.AutoSize = false;
            this.maxy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.maxy.Image = global::Interpolator.Properties.Resources.Maximize;
            this.maxy.ImageTransparentColor = System.Drawing.Color.White;
            this.maxy.Margin = new System.Windows.Forms.Padding(0);
            this.maxy.Name = "maxy";
            this.maxy.Size = new System.Drawing.Size(22, 22);
            this.maxy.Text = "Povecaj";
            this.maxy.Click += new System.EventHandler(this.OnClickMaximise);
            // 
            // miny
            // 
            this.miny.AutoSize = false;
            this.miny.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.miny.Image = global::Interpolator.Properties.Resources.Minimize;
            this.miny.ImageTransparentColor = System.Drawing.Color.White;
            this.miny.Margin = new System.Windows.Forms.Padding(0);
            this.miny.Name = "miny";
            this.miny.Size = new System.Drawing.Size(22, 22);
            this.miny.Text = "Smanji";
            this.miny.ToolTipText = "Smanji";
            this.miny.Click += new System.EventHandler(this.OnClickMinimise);
            // 
            // Naslov
            // 
            this.Naslov.AutoSize = false;
            this.Naslov.BackColor = System.Drawing.Color.DarkKhaki;
            this.Naslov.GripMargin = new System.Windows.Forms.Padding(0);
            this.Naslov.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Naslov.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Name_of_func});
            this.Naslov.Location = new System.Drawing.Point(0, 0);
            this.Naslov.Name = "Naslov";
            this.Naslov.Size = new System.Drawing.Size(344, 22);
            this.Naslov.Stretch = true;
            this.Naslov.TabIndex = 103;
            this.Naslov.Text = "toolStrip1";
            this.Naslov.Click += new System.EventHandler(this.OnClickTakeFocus);
            this.Naslov.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDownMove);
            this.Naslov.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUpMove);
            // 
            // Name_of_func
            // 
            this.Name_of_func.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Name_of_func.Image = ((System.Drawing.Image)(resources.GetObject("Name_of_func.Image")));
            this.Name_of_func.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Name_of_func.Name = "Name_of_func";
            this.Name_of_func.Size = new System.Drawing.Size(80, 19);
            this.Name_of_func.Text = "Funkction #0";
            this.Name_of_func.Click += new System.EventHandler(this.OnClickFuncName);
            // 
            // ErrorBox
            // 
            this.ErrorBox.ErrorImage = global::Interpolator.Properties.Resources.Error1;
            this.ErrorBox.Image = global::Interpolator.Properties.Resources.Error1;
            this.ErrorBox.Location = new System.Drawing.Point(141, 60);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(16, 16);
            this.ErrorBox.TabIndex = 105;
            this.ErrorBox.TabStop = false;
            this.ErrorBox.Visible = false;
            // 
            // funkcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Name = "funkcija";
            this.Size = new System.Drawing.Size(579, 365);
            this.points.ResumeLayout(false);
            this.points.PerformLayout();
            this.MyTable.ResumeLayout(false);
            this.MyTable.PerformLayout();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.Properties.ResumeLayout(false);
            this.Properties.PerformLayout();
            this.Izgled.ResumeLayout(false);
            this.Izgled.PerformLayout();
            this.Naslov.ResumeLayout(false);
            this.Naslov.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBox)).EndInit();
            this.ResumeLayout(false);

        }
        private Panel Panel;
        private GroupBox points;
        private Label y_label, func_label, koristi_label, izbrisi_label, global_id_label;
        private Button dodaj_button;

        private TextBox Input_x, Input_y;
        #endregion

        private ToolStrip Izgled;
        private ToolStripButton maxy;
        private ToolStripButton x_but;
        private ToolStripButton miny;
        private ToolStrip Naslov;
        private ToolStripButton Name_of_func;
        private ColorDialog colorDialog1;
        private ToolStrip Properties;
        private ToolStripButton Copy_button;
        private ToolStripButton Color;
        private ToolStripButton mode;
        private PictureBox ErrorBox;
        private TableLayoutPanel MyTable;
        private Label x_lable;
        private Label id_lable;
    }
}
