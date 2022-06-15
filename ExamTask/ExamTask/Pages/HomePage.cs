using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class HomePage : Form
    {
        private ILink ProjectLink(string ProjectName) => AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//div[contains(@class,'list-group')]//a[text()[contains(.,'{ProjectName}')]]"), $"{ProjectName} link");
        private IButton AddButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//div[contains(@class,'panel-heading')]//button"), "Add button");
        private ITextBox AddProjectNameInput = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("projectName"), "Add project name input");
        private IButton SaveProject = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//form[@id='addProjectForm']//button[@type='submit']"), "Save project button");

        public HomePage() : base(By.XPath("//div[contains(@class,'list-group')]"), "Home page")
        {

        }

        public void OpenProjectLink(string project)
        {
            ProjectLink(project).Click();
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }
    }
}
