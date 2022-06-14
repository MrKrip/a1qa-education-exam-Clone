using Aquality.Selenium.Browsers;
using ExamTask.ApiRequests;
using ExamTask.Models;
using ExamTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ExamTask
{
    public class Tests : BaseTest
    {
        private SecondVariantRequests Requests = new SecondVariantRequests();
        private HomePage homePage = new HomePage();

        [Test]
        public void ExamTask()
        {
            (var Token, var StatusCode) = Requests.GetToken(ConfigClass.Config["Variant"]);
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", Token, "localhost", "/",null));
            AqualityServices.Browser.Refresh();
            Assert.Pass();
        }
    }
}