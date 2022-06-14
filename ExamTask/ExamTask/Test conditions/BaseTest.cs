using Aquality.Selenium.Browsers;
using ExamTask.Models;
using ExamTask.Util;
using NUnit.Framework;

namespace ExamTask
{
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            ApiUtils.SetClient(ConfigClass.Config["ApiUrl"]);
            LoginModel user = ParseJson.GetDataFile<LoginModel>(ConfigClass.LoginInfoPath);
            AqualityServices.Browser.GoTo($"{ConfigClass.Config["MainPageUrl"].Split("//")[0]}//{user.Login}:{user.Password}@{ConfigClass.Config["MainPageUrl"].Split("//")[1]}");
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
