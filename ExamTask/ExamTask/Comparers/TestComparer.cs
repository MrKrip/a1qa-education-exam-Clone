using ExamTask.Models;
using System.Collections;

namespace ExamTask.Comparers
{
    public class TestComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var xtemp = x as TestsModel;
            var ytemp = y as TestsModel;
            return DateTime.Compare(DateTime.Parse(ytemp.StartTime), DateTime.Parse(xtemp.StartTime));
        }
    }
}
