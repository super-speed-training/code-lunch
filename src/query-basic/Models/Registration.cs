namespace query_basic.Models
{
    public class Registration
    {
        public int Id { get; }
        public string StudentId { get; }
        public string SubjectId { get; }

        public Registration(int id, string studentId, string subjectId)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
