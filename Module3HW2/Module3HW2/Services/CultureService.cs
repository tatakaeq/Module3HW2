using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Module3HW2.Services
{
    public class CultureService
    {
        public static string ChooseLanguage(CultureInfo cultureInfo)
        {
            string language = cultureInfo.ToString() switch
            {
                "ru-Ru" => ReadAlphabet("Russian"),
                _ => ReadAlphabet("English")
            };

            return language;
        }

        private static string ReadAlphabet(string language)
        {
            var cultureConfig = File.ReadAllText($"{language}.json");
            var config = JsonConvert.DeserializeObject<string>(cultureConfig);
            return config;
        }
    }
}