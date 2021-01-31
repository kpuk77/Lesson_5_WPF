using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson_5_WPF
{

    public partial class MainWindow
    {
        private static bool __IsSorted = true;

        public MainWindow()
        {
            InitializeComponent();
            Core.Initialize();
            cbDepartments.ItemsSource = Core.Departments;
        }

        private void BtnSortById_OnClick(object sender, RoutedEventArgs e)
        {
            if (!__IsSorted)
            {
                Core.Department.SortById();
                __IsSorted = true;
                ListBox.ItemsSource = Core.Department.GetList();
            }
            else
            {
                Core.Department.SortByIdDescending();
                __IsSorted = false;
                ListBox.ItemsSource = Core.Department.GetList();
            }
        }

        private void BtnSortByName_OnClick(object sender, RoutedEventArgs e)
        {
            if (!__IsSorted)
            {
                Core.Department.SortByName();
                __IsSorted = true;
                ListBox.ItemsSource = Core.Department.GetList();
            }
            else
            {
                Core.Department.SortByNameDescending();
                __IsSorted = false;
                ListBox.ItemsSource = Core.Department.GetList();
            }
        }

        private void BtnSortByPosition_OnClick(object sender, RoutedEventArgs e)
        {
            if (!__IsSorted)
            {
                Core.Department.SortByPosition();
                __IsSorted = true;
                ListBox.ItemsSource = Core.Department.GetList();
            }
            else
            {
                Core.Department.SortByPositionDescending();
                __IsSorted = false;
                ListBox.ItemsSource = Core.Department.GetList();
            }
        }

        private void CbDepartments_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedItem = (Department)comboBox.SelectedItem;
            if (selectedItem == null)
                return;
            Core.Department = selectedItem;
            ListBox.ItemsSource = Core.Department.GetList();
        }

        private void ListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var list = (ListBox)sender;
            var selectedItem = (Employee)list.SelectedItem;

            if (selectedItem == null)
                return;

            EditEmployeeWindow editEmployee = new EditEmployeeWindow(selectedItem);
            editEmployee.Title = $"Сотрудник {selectedItem.Name}";
            editEmployee.Show();
            editEmployee.Closing += (_, _) =>
            {
                ListBox.ItemsSource = null;
                ListBox.ItemsSource = Core.Department.GetList();
            };
        }

        private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Employee)ListBox.SelectedItem;

            if (selectedItem == null)
                return;

            EditEmployeeWindow editEmployee = new EditEmployeeWindow(selectedItem);
            editEmployee.Title = $"Сотрудник {selectedItem.Name}";
            editEmployee.Show();
            editEmployee.Closing += (_, _) =>
            {
                ListBox.ItemsSource = null;
                ListBox.ItemsSource = Core.Department.GetList();
            };
        }

        private void BtnAddEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (cbDepartments.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать группу.", "Внимание!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return;
            }
            EditEmployeeWindow editEmployee = new EditEmployeeWindow(new Employee { Department = (Department)cbDepartments.SelectedItem });
            editEmployee.Title = $"Сотрудник {this.Name}";
            editEmployee.Show();
        }

        private void BtnRemoveEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (cbDepartments.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать группу и сотрудника.", "Внимание!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return;
            }

            if (ListBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать сотрудника.", "Внимание!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return;
            }
            Core.Department.RemoveEmployee((Employee)ListBox.SelectedItem);
            //UpdateLists();
        }

        private void BtnAddGroup_OnClick(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.Show();
            editWindow.Closing += (_, _) =>
            {
                Core.AddNewGroup(editWindow.tbName.Text);
                UpdateLists();
                cbDepartments.SelectedItem = Core.Departments[^1];
            };
        }

        private void BtnEditGroup_OnClick(object sender, RoutedEventArgs e)
        {
            if (cbDepartments.SelectedItem == null)
                return;
            Core.Department = (Department)cbDepartments.SelectedItem;
            EditWindow editWindow = new EditWindow();
            editWindow.tbName.Text = Core.Department.Name;
            editWindow.Show();
            editWindow.Closing += (_, _) 
                =>
            {
                int index = cbDepartments.SelectedIndex;
                Core.Department.Name = editWindow.tbName.Text;
                UpdateLists();
                cbDepartments.SelectedItem = Core.Departments[index];
            };
        }

        private void BtnRemoveGroup_OnClick(object sender, RoutedEventArgs e)
        {
            Core.Departments.Remove((Department) cbDepartments.SelectedItem);
            cbDepartments.SelectedItem = Core.Departments[0];
        }

        private void UpdateLists()
        {
            cbDepartments.ItemsSource = null;
            cbDepartments.ItemsSource = Core.Departments;
            ListBox.ItemsSource = null;
            ListBox.ItemsSource = Core.Department.GetList();
        }
    }
}