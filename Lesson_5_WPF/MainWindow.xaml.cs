using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lesson_5_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Department department;
        private bool isSorted = true;

        public MainWindow()
        {
            InitializeComponent();
            department = new Department();
            ListBox.ItemsSource = department.GetList();
        }

        private void BtnSortById_OnClick(object sender, RoutedEventArgs e)
        {
            if (!isSorted)
            {
                department.SortById();
                isSorted = true;
                ListBox.ItemsSource = department.GetList();
            }
            else
            {
                department.SortByIdDescending();
                isSorted = false;
                ListBox.ItemsSource = department.GetList();
            }
        }

        private void BtnSortByName_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!isSorted)
            {
                department.SortByName();
                isSorted = true;
                ListBox.ItemsSource = department.GetList();
            }
            else
            {
                department.SortByNameDescending();
                isSorted = false;
                ListBox.ItemsSource = department.GetList();
            }
        }

        private void BtnSortByPosition_OnClick(object Sender, RoutedEventArgs E)
        {
            if (!isSorted)
            {
                department.SortByPosition();
                isSorted = true;
                ListBox.ItemsSource = department.GetList();
            }
            else
            {
                department.SortByPositionDescending();
                isSorted = false;
                ListBox.ItemsSource = department.GetList();
            }
        }
    }
}
