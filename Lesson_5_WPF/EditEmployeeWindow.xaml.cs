using System.Windows;

namespace Lesson_5_WPF
{
    public partial class EditEmployeeWindow
    {
        private bool IsNewEmployee = false;
        private Employee _Employee;
        public EditEmployeeWindow(Employee Emp)
        {
            if (Emp.Name == null)
                IsNewEmployee = true;

            _Employee = Emp;
            InitializeComponent();
            tbId.Text = Emp.Id.ToString();
            tbName.Text = Emp.Name;
            tbLastName.Text = Emp.LastName;
            tbMiddleName.Text = Emp.MiddleName;
            tbAge.Text = Emp.Age.ToString();
            //cbPosition.SelectedItem = emp.Position;
            cbDepartment.ItemsSource = Core.Departments;
            cbDepartment.SelectedItem = Emp.Department;
        }

        private void BtnSave_OnClick(object Sender, RoutedEventArgs E)
        {
            _Employee.Name = tbName.Text;
            _Employee.LastName = tbLastName.Text;
            _Employee.MiddleName = tbMiddleName.Text;
            if (int.TryParse(tbAge.Text, out var age))
                _Employee.Age = age;
            //_Employee.Position = (Position)cbPosition.SelectedItem;
            _Employee.Department = (Department)cbDepartment.SelectedItem;   // TODO: сделать перемещение сотрудника в другую группу, если она была изменена.
            if (IsNewEmployee)
                Core.Department.AddEmployee(_Employee);
            Close();
        }

        private void BtnCancel_OnClick(object Sender, RoutedEventArgs E) => Close();
    }
}
