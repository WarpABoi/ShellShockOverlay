using System.Globalization;
namespace ShellShockOverlay;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Form1";
        this.BackColor = System.Drawing.Color.Black;
        this.TransparencyKey = System.Drawing.Color.Black;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.TopMost = true;
        this.DoubleBuffered = true;
        this.WindowState = FormWindowState.Maximized;


        this.num_Angle = new System.Windows.Forms.NumericUpDown();
        this.num_Power = new System.Windows.Forms.NumericUpDown();
        this.btn_Calculate = new System.Windows.Forms.Button();
        this.hTrackBar = new System.Windows.Forms.TrackBar();
        this.vTrackBar = new System.Windows.Forms.TrackBar();
        this.pic_Overlay = new System.Windows.Forms.PictureBox();
        this.chk_AutoCalc = new System.Windows.Forms.CheckBox();
        this.SuspendLayout();


        this.num_Angle.Location = new System.Drawing.Point(50, 50);
        this.num_Angle.Name = "num_Angle";
        this.num_Angle.Size = new System.Drawing.Size(80, 23);
        this.num_Angle.TabIndex = 1;
        this.num_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.num_Angle.ValueChanged += new System.EventHandler(this.num_Angle_ValueChanged);
        this.num_Angle.Value = 45;
        this.num_Angle.Maximum = 89;
        this.num_Angle.Minimum = -89;
        this.Controls.Add(this.num_Angle);


        this.num_Power.Location = new System.Drawing.Point(50, 80);
        this.num_Power.Name = "num_Power";
        this.num_Power.Size = new System.Drawing.Size(80, 23);
        this.num_Power.TabIndex = 2;
        this.num_Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.num_Power.ValueChanged += new System.EventHandler(this.num_Power_ValueChanged);
        this.num_Power.Value = 100;
        this.num_Power.Maximum = 100;
        this.num_Power.Minimum = 1;
        this.Controls.Add(this.num_Power);


        this.btn_Calculate.Location = new System.Drawing.Point(50, 110);
        this.btn_Calculate.Name = "btn_Calculate";
        this.btn_Calculate.Size = new System.Drawing.Size(80, 23);
        this.btn_Calculate.TabIndex = 3;
        this.btn_Calculate.Text = "Calculate";
        this.btn_Calculate.UseVisualStyleBackColor = true;
        this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
        this.Controls.Add(this.btn_Calculate);


        this.hTrackBar.Location = new System.Drawing.Point(0, 0);
        this.hTrackBar.Name = "hTrackBar";
        this.hTrackBar.Size = new System.Drawing.Size(1920, 45);
        this.hTrackBar.TabIndex = 4;
        this.hTrackBar.ValueChanged += new System.EventHandler(this.hTrackBar_ValueChanged);
        this.hTrackBar.Maximum = 100;
        this.hTrackBar.Minimum = 0;
        this.hTrackBar.Value = 50;
        this.Controls.Add(this.hTrackBar);


        this.vTrackBar.Location = new System.Drawing.Point(0, 0);
        this.vTrackBar.Name = "vTrackBar";
        this.vTrackBar.Size = new System.Drawing.Size(45, 1080);
        this.vTrackBar.TabIndex = 5;
        this.vTrackBar.ValueChanged += new System.EventHandler(this.vTrackBar_ValueChanged);
        this.vTrackBar.Maximum = 100;
        this.vTrackBar.Minimum = 0;
        this.vTrackBar.Value = 50;
        this.vTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.Controls.Add(this.vTrackBar);


        this.pic_Overlay.Location = new System.Drawing.Point(0, 0);
        this.pic_Overlay.Name = "pic_Overlay";
        this.pic_Overlay.Size = new System.Drawing.Size(1920, 1080);
        this.pic_Overlay.TabIndex = 6;
        this.pic_Overlay.TabStop = false;
        this.pic_Overlay.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.pic_Overlay);


        this.chk_AutoCalc.Location = new System.Drawing.Point(50, 140);
        this.chk_AutoCalc.Name = "chk_AutoCalc";
        this.chk_AutoCalc.Size = new System.Drawing.Size(80, 23);
        this.chk_AutoCalc.TabIndex = 7;
        this.chk_AutoCalc.Text = "AutoCalc";
        this.chk_AutoCalc.UseVisualStyleBackColor = true;
        this.chk_AutoCalc.Checked = false;
        this.Controls.Add(this.chk_AutoCalc);
    }

    #endregion

    private NumericUpDown num_Angle;
    private NumericUpDown num_Power;
    private Button btn_Calculate;
    private TrackBar hTrackBar;
    private TrackBar vTrackBar;
    private PictureBox pic_Overlay;
    private CheckBox chk_AutoCalc;
}
