using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson_5_WPF
{
    public static class Core
    {
        private static ObservableCollection<Department> _Departments;
        private static Department _Department;

        public static Department Department
        {
            get => _Department;
            set => _Department = value;
        }

        public static ObservableCollection<Department> Departments
        {
            get => _Departments;
            set => _Departments = value;
        }

        public static void Initialize()
        {
            _Departments = new ObservableCollection<Department>(Enumerable
                .Range(1, 8)
                .Select(s => new Department())
                .ToList());
        }

        public static void AddNewGroup(string Name)
        {
            Department department = new Department(Name);
            _Departments.Add(department);
        }
    }
}
