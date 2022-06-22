namespace ExamTask.Models
{
    public class TestsModel : IEquatable<TestsModel?>
    {
        public string Duration { get; set; }
        public string Method { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TestsModel);
        }

        public bool Equals(TestsModel? other)
        {
            return other is not null &&
                   Duration.ToLower() == other.Duration &&
                   Method.ToLower() == other.Method &&
                   Name.ToLower() == other.Name &&
                   StartTime.ToLower() == other.StartTime &&
                   Status.ToLower() == other.Status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Duration, Method, Name, StartTime, EndTime, Status);
        }
    }
}
