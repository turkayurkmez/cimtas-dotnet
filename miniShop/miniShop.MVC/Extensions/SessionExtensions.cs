using Newtonsoft.Json;

namespace miniShop.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static T GetJson<T>(this ISession session, string key) where T : class, new()
        {
            var serializedString = session.GetString(key);
            return serializedString == null ? default(T) : JsonConvert.DeserializeObject<T>(serializedString);
        }

        public static void SetJson<T>(this ISession session, string key, T value) where T : class, new()
        {

            var serialized = JsonConvert.SerializeObject(value);
            session.SetString(key, serialized);
        }
    }
}
