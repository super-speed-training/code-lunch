namespace query_basic.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
        }

        public Student(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
