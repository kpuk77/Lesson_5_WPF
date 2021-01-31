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
        private ObservableCollection<Department> _Departments;
        private Department _Department;
        private bool _IsSorted = true;

        public MainWindow()
        {
            InitializeComponent();
            _Departments = new ObservableCollection<Department>(Enumerable
                .Range(1, 8)
                .Select(s => new Department())
                .ToList());
            cbDepartments.ItemsSource = _Departments;
        }

        private void BtnSortById_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_IsSorted)
            {
                _Department.SortById();
                _IsSorted = true;
                ListBox.ItemsSource = _Department.GetList();
            }
            else
            {
                _Department.SortByIdDescending();
                _IsSorted = false;
                ListBox.ItemsSource = _Department.GetList();
            }
        }

        private void BtnSortByName_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!_IsSorted)
            {
                _Department.SortByName();
                _IsSorted = true;
                ListBox.ItemsSource = _Department.GetList();
            }
            else
            {
                _Department.SortByNameDescending();
                _IsSorted = false;
                ListBox.ItemsSource = _Department.GetList();
            }
        }

        private void BtnSortByPosition_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!_IsSorted)
            {
                _Department.SortByPosition();
                _IsSorted = true;
                ListBox.ItemsSource = _Department.GetList();
            }
            else
            {
                _Department.SortByPositionDescending();
                _IsSorted = false;
                ListBox.ItemsSource = _Department.GetList();
            }
        }

        private void CbDepartments_OnSelectionChanged(object Sender, SelectionChangedEventArgs E)
        {
            var comboBox = (ComboBox) Sender;
            var selectedItem = (Department) comboBox.SelectedItem;
            _Department = selectedItem;
            ListBox.ItemsSource = _Department.GetList();
        }

        private void ListBox_OnMouseDoubleClick(object Sender, MouseButtonEventArgs E)
        {
            var list = (ListBox) Sender;
            var selectedItem = (Employee) list.SelectedItem;

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
            var selectedItem = (Employee) ListBox.SelectedItem;

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
            EditEmployeeWindow editEmployee = new EditEmployeeWindow(new Employee{Department = (Department)cbDepartments.SelectedItem});
            editEmployee.Title = $"Сотрудник {this.Name}";
            editEmployee.Show();
        }

        public void AddNewEmployee(Employee emp)
        {
            _Department.AddEmployee(emp);
        }
    }
}