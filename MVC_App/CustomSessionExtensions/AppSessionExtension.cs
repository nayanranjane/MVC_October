using System.Text.Json;
namespace MVC_App.CustomSessionExtensions
{
    public static class AppSessionExtension
    {
        public static void SetObject<T>(this ISession session,string key, T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T GetObject<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            if (value == null)
                return default(T);
            else
                return JsonSerializer.Deserialize<T>(value);
        }
    }
}
