using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class HomePage : Form
    {
        private ILink ProjectLink(string ProjectName) => AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//div[contains(@class,'list-group')]//a[text()[contains(.,'{ProjectName}')]]"), $"{ProjectName} link");
        private IButton AddButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//div[contains(@class,'panel-heading')]//*[contains(@class,'btn')]"), "Add button");

        public HomePage() : base(By.XPath("//div[contains(@class,'list-group')]"), "Home page")
        {

        }

        public void OpenProjectLink(string project)
        {
            ProjectLink(project).Click();
        }

        public void ClickAddButton()
        {
            AddButton.State.WaitForClickable();
            AddButton.Click();
        }

        public bool IsProjectExist(string ProjectName)
        {
            return ProjectLink(ProjectName).State.WaitForDisplayed();
        }
    }
}
