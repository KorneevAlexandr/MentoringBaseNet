namespace Reflection.Task1.Extensions
{
    public static class ConvertExtensions
    {
        public static bool IsDefault(this Type type)
        {
            return type == typeof(int) || type == typeof(float) || type == typeof(string);
        }
    }
}
