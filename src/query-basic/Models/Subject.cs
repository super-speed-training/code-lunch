namespace query_basic.Models
{
    public class Subject
    {
        public string Id { get; }
        public string Name { get; }
        public string TeacherId { get; }

        public Subject(string id, string name, string teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }
    }
}
