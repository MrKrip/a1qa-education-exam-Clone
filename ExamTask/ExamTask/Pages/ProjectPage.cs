using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExamTask.Models;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class ProjectPage : Form
    {
        private ILabel TestParameter(int RowIndex, int ElementIndex) => AqualityServices.Get<IElementFactory>().GetLabel(By.XPath($"//table[contains(@class,'table')]//tr[td][{RowIndex}]//td[{ElementIndex}]"), "Test parameter");
        private ILink TestLink(string id) => AqualityServices.Get<IElementFactory>().GetLink(By.XPath($"//*[@id='allTests']//a[contains(@href,'testId={id}')]"), "Test link");

        public ProjectPage() : base(By.Id("pie"), "Project page")
        {

        }

        public List<TestsModel> GetTestsList()
        {
            List<TestsModel> tests = new List<TestsModel>();
            TestParameter(1, 1).State.WaitForExist();

            for (int i = 1; TestParameter(i, 1).State.IsExist; i++)
            {
                tests.Add(new TestsModel()
                {
                    Name = TestParameter(i, 1).Text.ToLower(),
                    Duration = TestParameter(i, 6).Text.ToLower(),
                    EndTime = TestParameter(i, 5).Text.ToLower(),
                    Method = TestParameter(i, 2).Text.ToLower(),
                    StartTime = TestParameter(i, 4).Text.ToLower(),
                    Status = TestParameter(i, 3).Text.ToLower()
                });
            }
            return tests;
        }

        public bool IsTestExist(string id)
        {
            return TestLink(id).State.WaitForDisplayed();
        }
    }
}
