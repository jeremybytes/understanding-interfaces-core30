using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;
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
            FetchData("Service");
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData("CSV");
        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData("SQL");
        }

        private void FetchData(string readerType)
        {
            ClearListBox();

            IPersonReader reader = ReaderFactory.GetReader(readerType);

            var people = reader.GetPeople();
            foreach (var person in people)
                PersonListBox.Items.Add(person);

            ShowReaderType(reader);
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
