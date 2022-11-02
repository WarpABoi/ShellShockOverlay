using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
namespace ShellShockOverlay;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private void btn_Calculate_Click(object sender, EventArgs e)
    {
        float angle = 0;
        float power = 0;
        float height = 0;
        float x = 0;
        angle = (float)num_Angle.Value;
        power = (float)num_Power.Value;
        height = vTrackBar.Value / 1000f * 1080;
        x = hTrackBar.Value / 1000f * 1920;
        Update(angle, power, height, x);
    }
    private void Update(float angle, float power, float height, float x)
    {
        if (this.pic_Overlay.InvokeRequired)
        {
            UpdateCallback d = new UpdateCallback(Update);
            this.Invoke(d, new object[] { angle, power, height, x });
        }
        bool hFlip = false;
        if (angle > 90 || angle < -90)
        {
            angle = -angle;
            hFlip = true;
        }
        System.Console.WriteLine("drawing @ " + angle + "° " + power + " " + height + " " + x + " " + hFlip);
        var image = new Image<Rgba32>(1920, 1080, new Rgba32(0, 0, 0, 0));
        calc.CalculateTrajectory(angle, power * 1.59f, height);
        var lastX = 0;
        var lastY = ((int)calc.GetYatX(lastX));
        for (int i = 0; i < 1920; i++)
        {
            int y = (int)calc.GetYatX(i);
            if (y < 0)
                continue;
            try
            {
                image.Mutate(x => x.DrawLines(new DrawingOptions(), new SixLabors.ImageSharp.Drawing.Processing.Pen(SixLabors.ImageSharp.Color.Red, 1),
                new SixLabors.ImageSharp.PointF[] { new SixLabors.ImageSharp.PointF(lastX, image.Height - lastY), new SixLabors.ImageSharp.PointF(i, image.Height - y) }));
            }
            catch
            {
                System.Console.WriteLine("Error at " + i + ", " + y);
            }
            lastX = i;
            lastY = y;
        }
        if (hFlip)
        {
            image.Mutate(x => x.Flip(FlipMode.Horizontal));
        }
        Stream stream = new MemoryStream();
        image.SaveAsPng(stream);
        stream.Position = 0;
        this.pic_Overlay.Image = System.Drawing.Image.FromStream(stream);

        this.pic_Overlay.Location = new System.Drawing.Point(hFlip ? (int)(x - 1920) : (int)(x), 0);
    }
    delegate void UpdateCallback(float angle, float power, float height, float x);
    float hTrackBar_Value = 0;
    private void hTrackBar_ValueChanged(object sender, EventArgs e)
    {
        hTrackBar_Value = hTrackBar.Value;
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    float vTrackBar_Value = 0;
    private void vTrackBar_ValueChanged(object sender, EventArgs e)
    {
        vTrackBar_Value = vTrackBar.Value;
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    float num_Angle_Value = 0;
    private void num_Angle_ValueChanged(object sender, EventArgs e)
    {
        num_Angle_Value = (float)num_Angle.Value;
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    float num_Power_Value = 0;
    private void num_Power_ValueChanged(object sender, EventArgs e)
    {
        num_Power_Value = (float)num_Power.Value;
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    System.Timers.Timer timer = new System.Timers.Timer(500);
    private void txt_Path_TextChanged(object sender, EventArgs e)
    {
        string root = txt_Path.Text.Replace('/', '\\').TrimEnd('\\');
        if (Directory.Exists(root)
            && File.Exists(root + "\\degrees")
            && File.Exists(root + "\\power")
            && File.Exists(root + "\\position"))
        {
            timer.Stop();
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }
        else
        {
            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;
        }
    }
    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        try
        {
            float angle = 0;
            float power = 0;
            // float height = 0;
            float x = 0;
            string root = txt_Path.Text.Replace('/', '\\').TrimEnd('\\');
            if (File.Exists(root + "\\degrees"))
            {
                string degrees = File.ReadAllText(root + "\\degrees");
                if (degrees != num_Angle.Value.ToString())
                {
                    angle = float.Parse(degrees);
                }
            }
            if (File.Exists(root + "\\power"))
            {
                string powerStr = File.ReadAllText(root + "\\power");
                if (powerStr != num_Power.Value.ToString())
                {
                    power = float.Parse(powerStr);
                }
            }
            if (File.Exists(root + "\\position"))
            {
                string position = File.ReadAllText(root + "\\position").Split('.')[0];
                x = float.Parse(position);
            }
            angle = 90 - angle;
            Update(angle, power, vTrackBar_Value / 1000f * 1080, x / 1000f * 1920);
        }
        catch
        {

        }
    }
}
