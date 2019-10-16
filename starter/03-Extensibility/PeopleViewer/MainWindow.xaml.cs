using PersonReader.Interface;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
        }

        private void ShowReaderType(IPersonReader reader)
        {
            MessageBox.Show($"Reader Type:\n{reader.GetType()}");
        }
    }
}
