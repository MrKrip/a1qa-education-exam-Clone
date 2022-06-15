namespace ExamTask.Models
{
    public class TestsModel : IEquatable<TestsModel?>
    {
        public string duration { get; set; }
        public string method { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string status { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TestsModel);
        }

        public bool Equals(TestsModel? other)
        {
            if (name == other.name)
            {
                var a = 1;
            }
            return other is not null &&
                   duration.ToLower() == other.duration &&
                   method.ToLower() == other.method &&
                   name.ToLower() == other.name &&
                   startTime.ToLower() == other.startTime &&
                   status.ToLower() == other.status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(duration, method, name, startTime, endTime, status);
        }
    }
}
