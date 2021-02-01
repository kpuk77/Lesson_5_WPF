using System.Windows;

namespace Lesson_5_WPF
{
    public partial class EditEmployeeWindow
    {
        private bool _IsNewEmployee;
        private Employee _Employee;
        public EditEmployeeWindow(Employee emp)
        {
            if (emp.Name == null)
                _IsNewEmployee = true;

            _Employee = emp;
            InitializeComponent();
            tbId.Text = emp.Id.ToString();
            tbName.Text = emp.Name;
            tbLastName.Text = emp.LastName;
            tbMiddleName.Text = emp.MiddleName;
            tbAge.Text = emp.Age.ToString();
            //cbPosition.SelectedItem = emp.Position;                       //  TODO:   привязать ComboBox cbPosition к enum Position
            cbDepartment.ItemsSource = Core.Departments;
            cbDepartment.SelectedItem = emp.Department;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("Введите имя!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            _Employee.Name = tbName.Text;
            _Employee.LastName = tbLastName.Text;
            _Employee.MiddleName = tbMiddleName.Text;
            if (int.TryParse(tbAge.Text, out var age))
                _Employee.Age = age;
            //_Employee.Position = (Position)cbPosition.SelectedItem;
            _Employee.Department = (Department)cbDepartment.SelectedItem;   // TODO: сделать перемещение сотрудника в другую группу, если она была изменена.
            if (_IsNewEmployee)
                Core.Department.AddEmployee(_Employee);
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e) => Close();
    }
}
