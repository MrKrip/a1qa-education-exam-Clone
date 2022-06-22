using ExamTask.Util;

namespace ExamTask
{
    public class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly Dictionary<string, string> Config = ParseJson.ReadConfigFile(DefaultPath + @"\Resources\Config.json");
        public static readonly string ConfigPath = DefaultPath + @"\Resources\config.json";
        public static readonly string LoginInfoPath = DefaultPath + @"\Resources\LoginInfo.json";
    }
}
