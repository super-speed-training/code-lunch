namespace query_basic.Models
{
    public class Registration
    {
        public int Id { get; }
        public string StudentId { get; }
        public string SubjectId { get; }
        public string Semester { get; }
        public int Grade { get; }

        public Registration(int id, string studentId, string subjectId, string semester, int grade)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
            Grade = grade;
            Semester = semester;
        }
    }
}
