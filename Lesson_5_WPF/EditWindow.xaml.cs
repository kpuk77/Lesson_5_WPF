using System.Windows;

namespace Lesson_5_WPF
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void BtnSaveEdit_OnClick(object sender, RoutedEventArgs e) => Close();
    }
}
