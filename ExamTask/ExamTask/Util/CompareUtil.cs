using ExamTask.Models;

namespace ExamTask.Util
{
    public static class CompareUtil
    {
        public static bool IsTestsSortedByDate(List<TestsModel> tests)
        {
            for (int i = 0; i < tests.Count() - 1; i++)
            {
                if (DateTime.Compare(DateTime.Parse(tests[i].startTime), DateTime.Parse(tests[i+1].startTime))<0)
                    return false;
            }
            return true;
        }

        public static bool AreTestsContainsInList(List<TestsModel> smallList,List<TestsModel> bigList)
        {
            foreach (TestsModel test in smallList)
            {
                if(!bigList.Contains(test))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
