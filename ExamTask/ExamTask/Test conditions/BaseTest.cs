using Aquality.Selenium.Browsers;
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
            AqualityServices.Browser.GoTo(ConfigClass.Config["MainPageUrl"]);
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
