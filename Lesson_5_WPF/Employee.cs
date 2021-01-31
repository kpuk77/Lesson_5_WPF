namespace Lesson_5_WPF
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        public Position Position { get; set; }

        public Department Department { get; set; }

        public override string ToString() => $"{Id} {Name} {LastName} {MiddleName} {Age} {Position} {Department}";
    }
}
