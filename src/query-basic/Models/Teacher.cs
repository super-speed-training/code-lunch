namespace query_basic.Models
{
    public class Teacher
    {
        public string Id { get; }
        public string Name { get; }

        public Teacher(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
