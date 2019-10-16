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

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();

            IPersonReader reader = ReaderFactory.GetReader();

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
