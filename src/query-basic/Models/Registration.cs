namespace query_basic.Models
{
    public class Registration
    {
        public string Id { get; }
        public string StudentId { get; }
        public string SubjectId { get; }

        public Registration(string id, string studentId, string subjectId)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
