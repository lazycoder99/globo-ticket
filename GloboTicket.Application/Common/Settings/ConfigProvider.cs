using GatewaySvc.Domain.Entities;

namespace GatewaySvc.Application.Common.Settings
{
    public class ConfigProvider
    {
        protected static readonly List<Setting> Setting = [];
        protected static readonly List<LocaleSetting> LocaleSettings = [];

        public static string? Find(Enum key)
        {
            return LocaleSettings.FirstOrDefault(x => x.Key == key.ToString())?.Value;
        }

        public static string Find(string key, string defaultUrl)
        {
            var val = ConfigProvider.Setting.Find(x => x.Key == key)?.Value;
            return val ?? defaultUrl;
        }

        public static bool Find(string key, bool defaultValue)
        {
            var val = Setting.Find(x => x.Key == key)?.Value;

            if (string.IsNullOrEmpty(val))
                return defaultValue;

            bool.TryParse(val, out defaultValue);
            return defaultValue;
        }

        public static int Find(string key, int defaultValue)
        {
            var val = ConfigProvider.Setting.Find(x => x.Key == key)?.Value;

            if (string.IsNullOrEmpty(val))
                return defaultValue;

            int.TryParse(val, out defaultValue);
            return defaultValue;
        }
    }
}
