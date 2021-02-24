using System;

namespace Infrastructure.FluentExtensions
{
    public static class FluentExtensions
    {
        public static T Do<T>(this T obj, Action<T> action)
        {
            return Do<T>(obj, action, true);
        }

        public static T Do<T>(this T obj, Action<T> action, bool when)
        {
            if (when) 
                action?.Invoke(obj);

            return obj;
        }
        
        public static T Do<T>(this T obj, Action<T> action, Func<bool> when)
        {
            if (when()) 
                action?.Invoke(obj);

            return obj;
        }
    }
}