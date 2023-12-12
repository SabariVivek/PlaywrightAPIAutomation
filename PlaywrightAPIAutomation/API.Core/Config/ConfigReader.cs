using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Core.Config
{
    public class ConfigReader
    {
        public static TestConfiguration ReadConfig()
        {
            string RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string WorkingSpaceDirectory = RootDirectory.Split(new string[] { "\\bin", "\\Debug" }, StringSplitOptions.None)[0];
            var configFile = File.ReadAllText(WorkingSpaceDirectory + "/config.json");

            var jsonSerializeOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            jsonSerializeOptions.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<TestConfiguration>(configFile, jsonSerializeOptions)!;
        }
    }
}