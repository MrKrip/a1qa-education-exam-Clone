using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTask.Pages
{
    public class HomePage:Form
    {


        public HomePage():base(By.XPath("//div[contains(@class,'list-group')]"),"Home page")
        {

        }
    }
}
