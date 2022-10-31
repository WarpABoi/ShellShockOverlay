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
        height = vTrackBar.Value / 100f * 1080;
        x = hTrackBar.Value / 100f * 1920;
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
        Stream stream = new MemoryStream();
        image.SaveAsPng(stream);
        stream.Position = 0;
        this.pic_Overlay.Image = System.Drawing.Image.FromStream(stream);
        this.pic_Overlay.Location = new System.Drawing.Point(((int)x), 0);
    }
    private void hTrackBar_ValueChanged(object sender, EventArgs e)
    {
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    private void vTrackBar_ValueChanged(object sender, EventArgs e)
    {
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    private void num_Angle_ValueChanged(object sender, EventArgs e)
    {
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
    private void num_Power_ValueChanged(object sender, EventArgs e)
    {
        if (chk_AutoCalc.Checked)
            btn_Calculate_Click(sender, e);
    }
}
