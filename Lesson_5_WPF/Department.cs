using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5_WPF
{
    public class Department
    {
        private int Id { get; init; }
        private List<Employee> _Employees;

        public string Name { get; set; }

        public Department()
        {
            _Employees = new List<Employee>(35);
            Position p = Position.Employee;

            for (int i = 1; i <= 35; i++)
            {
                _Employees.Add(new Employee
                {
                    Id = i,
                    Name = $"Имя {i}",
                    LastName = $"Фамилия {i}",
                    MiddleName = $"Отчество {i}",
                    Age = i < 18 ? i + 20 : i,
                    Position = p++ >= Position.Trainee?Position.Freelancer : Position.Employee, //  TODO
                    Department = this
                });
            }
        }

        public void AddEmployee(Employee Employee) => _Employees.Add(Employee);

        public void RemoveEmployee(Employee Employee) => _Employees.Remove(Employee);

        public void SortByNameDescending() => _Employees.OrderByDescending(s => s.Name);

        public void SortByPositionDescending() => _Employees.OrderByDescending(s => s.Position);

        public void SortByName() => _Employees.OrderBy(s => s.Name);

        public void SortByPosition() => _Employees.OrderBy(s => s.Position);

        public List<Employee> GetList() => _Employees;

        public override string ToString() => Name;
    }
}
