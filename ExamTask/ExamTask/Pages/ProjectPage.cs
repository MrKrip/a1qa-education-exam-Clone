using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExamTask.Models;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class ProjectPage : Form
    {
        private IList<ILabel> TestsParameters() => AqualityServices.Get<IElementFactory>().FindElements<ILabel>(By.XPath("//table[contains(@class,'table')]//tr//td"));
        private ILabel TestParameter = AqualityServices.Get<IElementFactory>().GetLabel(By.XPath("//table[contains(@class,'table')]//tr//td"),"Test parameter");

        public ProjectPage() : base(By.Id("pie"), "Project page")
        {

        }

        public List<TestsModel> GetTestsList()
        {
            List<TestsModel> tests = new List<TestsModel>();
            TestParameter.State.WaitForExist();
            var TestParameters = TestsParameters();

            for (int i = 0; i < TestParameters.Count; i++)
            {
                string name = String.Empty, duration = String.Empty, method = String.Empty, startTime = String.Empty, endTime = String.Empty, status = String.Empty;
                for (int j = 1; j < 7; j++)
                {
                    if (j == 1)
                    {
                        name = TestParameters[i].Text.ToLower();
                    }
                    else if (j == 2)
                    {
                        method = TestParameters[i].Text.ToLower();
                    }
                    else if (j == 3)
                    {
                        status = TestParameters[i].Text.ToLower();
                    }
                    else if (j == 4)
                    {
                        startTime = TestParameters[i].Text.ToLower();
                    }
                    else if (j == 5)
                    {
                        endTime = TestParameters[i].Text.ToLower();
                    }
                    else if (j == 6)
                    {
                        duration = TestParameters[i].Text.ToLower();
                    }
                    i++;
                }
                tests.Add(new TestsModel() { name = name, duration = duration, endTime = endTime, method = method, startTime = startTime, status = status });
            }
            return tests;
        }
    }
}
