namespace ShellShockOverlay
{
    public class calc
    {
        private static double gravity = 10;
        private static double Angle = 1;
        private static double velocity = 100;
        private static double StartHeight = 0;
        public static void CalculateTrajectory(float angle, float power, float height)
        {
            Angle = angle * (float)Math.PI / 180.0f;
            velocity = power;
            StartHeight = height;
        }

        public static double GetYatX(double x)
        {
            // return (x * Math.Tan(Angle) - gravity * ((x * x) / (2 * (velocity * Math.Cos(Angle)) * (velocity * Math.Cos(Angle)))));
            return (x * Math.Tan(Angle) - gravity * ((x * x) / (2 * (velocity * Math.Cos(Angle)) * (velocity * Math.Cos(Angle))))) + StartHeight;
        }
    }
}