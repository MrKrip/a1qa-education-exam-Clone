using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class AddProjectPage : Form
    {
        private ITextBox ProjectNameInput = AqualityServices.Get<IElementFactory>().GetTextBox(By.Id("projectName"), "Project name input");
        private IButton SaveProjectButton = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//*[@id='addProjectForm']//button[@type='submit']"), "Save project button");
        private ILabel SaveProjectAlert = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//*[@id='addProjectForm']//div[contains(@class,'alert')]"), "Save project alert");

        public AddProjectPage() : base(By.Id("projectName"), "Add project page")
        {

        }

        public void AddNewProject(string name)
        {
            ProjectNameInput.State.WaitForDisplayed();
            ProjectNameInput.SendKeys(name);
            SaveProjectButton.Click();
        }

        public bool IsAlertDisplayed()
        {
            return SaveProjectAlert.State.WaitForDisplayed();
        }
    }
}
