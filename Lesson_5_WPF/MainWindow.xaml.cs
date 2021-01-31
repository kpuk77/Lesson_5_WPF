using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson_5_WPF
{

    public partial class MainWindow : Window
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

        private void BtnSortByName_OnClick(object Sender, RoutedEventArgs E)
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

        private void BtnSortByPosition_OnClick(object Sender, RoutedEventArgs E)
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

        private void CbDepartments_OnSelectionChanged(object Sender, SelectionChangedEventArgs E)
        {
            var comboBox = (ComboBox)Sender;
            var selectedItem = (Department)comboBox.SelectedItem;
            if (selectedItem == null)
                return;
            Core.Department = selectedItem;
            ListBox.ItemsSource = Core.Department.GetList();
        }

        private void ListBox_OnMouseDoubleClick(object Sender, MouseButtonEventArgs E)
        {
            var list = (ListBox)Sender;
            var selectedItem = (Employee)list.SelectedItem;

            if (selectedItem == null)
                return;

            EditEmployeeWindow editEmployee = new EditEmployeeWindow(selectedItem);
            editEmployee.Title = $"Сотрудник {selectedItem.Name}";
            editEmployee.Show();
            //editEmployee.Closing += EditEmployee_Closing;
        }

        //private void EditEmployee_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
        //    => ListBox.ItemsSource = _Department.GetList();
        private void BtnEditEmployee_OnClick(object Sender, RoutedEventArgs E)
        {
            var selectedItem = (Employee)ListBox.SelectedItem;

            if (selectedItem == null)
                return;

            EditEmployeeWindow editEmployee = new EditEmployeeWindow(selectedItem);
            editEmployee.Title = $"Сотрудник {selectedItem.Name}";
            editEmployee.Show();
        }

        private void BtnAddEmployee_OnClick(object Sender, RoutedEventArgs E)
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

        private void BtnRemoveEmployee_OnClick(object Sender, RoutedEventArgs E)
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
        }

        private void BtnAddGroup_OnClick(object Sender, RoutedEventArgs E)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.Show();
            editWindow.Closing += (O, Args) => Core.AddNewGroup(editWindow.tbName.Text);
        }

        private void BtnEditGroup_OnClick(object Sender, RoutedEventArgs E)
        {
            if (cbDepartments.SelectedItem == null)
                return;
            Core.Department = (Department)cbDepartments.SelectedItem;
            EditWindow editWindow = new EditWindow();
            editWindow.tbName.Text = Core.Department.Name;
            editWindow.Show();
            editWindow.Closing += (O, Args) 
                =>
            {
                Core.Department.Name = editWindow.tbName.Text;
                cbDepartments.ItemsSource = Core.Departments;
            };
        }

        private void BtnRemoveGroup_OnClick(object Sender, RoutedEventArgs E) 
            => Core.Departments.Remove((Department) cbDepartments.SelectedItem);
    }
}