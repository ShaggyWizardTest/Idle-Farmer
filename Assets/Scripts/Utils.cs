public static class Utils
{
    public static bool TryGetClass<T>(object @object, out T @class) where T : class
    {
        @class = @object as T;
        return @object is T;
    }
}