namespace Rhodos.Toolkit.Extensions
{
    public static class FloatExtensions
    {
        public static float Abs(this float f)
        {
            return (f < 0) ? -f : f;
        }
    }
}