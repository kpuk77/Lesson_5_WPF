using System.Collections.ObjectModel;
using System.Linq;

namespace Lesson_5_WPF
{
    public static class Core
    {
        private static ObservableCollection<Department> __Departments;
        private static Department __Department;

        public static Department Department
        {
            get => __Department;
            set => __Department = value;
        }

        public static ObservableCollection<Department> Departments
        {
            get => __Departments;
            set => __Departments = value;
        }

        public static void Initialize()
        {
            __Departments = new ObservableCollection<Department>(Enumerable
                .Range(1, 8)
                .Select(_ => new Department())
                .ToList());
        }

        public static void AddNewGroup(string name)
        {
            Department department = new Department(name);
            __Departments.Add(department);
        }
    }
}
