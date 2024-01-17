using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfListBoxDemo.Data;

namespace WpfListBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> Persons = new List<Person>()
        {
            new Person{Name = "Elton", Age = 1},
            new Person{Name = "Jane", Age = 2},
            new Person{Name = "Marc", Age = 3},
        };
        public MainWindow()
        {
            InitializeComponent();
            ListBoxPeople.ItemsSource = Persons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = ListBoxPeople.SelectedItems;
            foreach (var item in selectedItems)
            {
                var person = (Person)item;
                MessageBox.Show(person.Name);
            }
        }
    }
}