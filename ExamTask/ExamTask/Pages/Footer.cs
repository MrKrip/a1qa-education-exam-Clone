using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class Footer : Form
    {
        private ILabel TaskVersion = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//footer[contains(@class,'footer')]//span"), "Task version in footer");

        public Footer() : base(By.XPath("//footer[contains(@class,'footer')]"), "Footer")
        {

        }

        public bool IsTaskVersionCorrect(string version)
        {
            return TaskVersion.Text == $"Version: {version}";
        }
    }
}
