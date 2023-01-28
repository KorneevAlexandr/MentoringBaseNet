namespace HttpTask.Listener.Extensions;

public static class ObjectExtensions
{
	public static bool In<T>(this T item, params T[] items) => items.Contains(item);
}
