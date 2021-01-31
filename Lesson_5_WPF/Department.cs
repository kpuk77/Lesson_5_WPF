using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lesson_5_WPF
{
    public class Department
    {
        private static int _Count = 0;
        private int Id { get; init; }
        private ObservableCollection<Employee> _Employees;

        public string Name { get; set; }

        public Department()
        {
            _Count++;
            Id = _Count;
            Random rand = new Random();
            _Employees = new ObservableCollection<Employee>();
            Position p = Position.Employee;
            Name = $"Группа - {rand.Next(1, 101)}";
            for (int i = 1; i <= 35; i++)
            {
                _Employees.Add(new Employee
                {
                    Name = $"Имя - {i}",
                    LastName = $"Фамилия - {i}",
                    MiddleName = $"Отчество - {i}",
                    Age = i < 18 ? i + 20 : i,
                    Position = p++ >= Position.Trainee?Position.Freelancer : Position.Employee, //  TODO
                    Department = this
                });
            }
        }

        public void AddEmployee(Employee Employee) => _Employees.Add(Employee);

        public void RemoveEmployee(Employee Employee) => _Employees.Remove(Employee);

        public void SortById()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderBy(s => s.Id));
            _Employees = sortedList;
        }

        public void SortByName()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderBy(s => s.Name));
            _Employees = sortedList;
        }

        public void SortByPosition()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderBy(s => s.Position));
            _Employees = sortedList;
        }

        public void SortByIdDescending()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderByDescending(s => s.Id));
            _Employees = sortedList;
        }

        public void SortByNameDescending()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderByDescending(s => s.Name));
            _Employees = sortedList;
        }

        public void SortByPositionDescending()
        {
            var sortedList = new ObservableCollection<Employee>(_Employees.OrderByDescending(s => s.Position));
            _Employees = sortedList;
        }

        public ObservableCollection<Employee> GetList() => _Employees;

        public override string ToString() => Name;
    }
}
