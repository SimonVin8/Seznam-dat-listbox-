using Seznam_dat__listbox_.Models;
using System.Collections.ObjectModel;
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

namespace Seznam_dat__listbox_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //observable collection se sama refreshne při přidání nového prvku
        public ObservableCollection<car> Cars { get; set; }
        public MainWindow()
        {
            Cars = new();
            InitializeComponent();
            ListData.ItemsSource = Cars;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string brand = ValidateTextInput(BrandInput.Text) ? BrandInput.Text : throw new Exception("BrandInput value is not supported");
                string model = ValidateTextInput(ModelInput.Text) ? ModelInput.Text : throw new Exception("ModelInput value is not supported"); ;
                if (!ValidateInteger(PowerInput.Text, out int power)) throw new Exception("PowerInput value is not supported");


                car car = new car() { Brand = brand, Model = model, Power = power };
                Cars.Add(car);
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private bool ValidateTextInput(string value)
        {

            return !(string.IsNullOrEmpty(value) || value.Length == 0);
        }

        private bool ValidateInteger(string value, out int number)
        {
            return int.TryParse(value, out number) && value.Length > 0;
        }

        public void Clear()
        {
            BrandInput.Text = ModelInput.Text = PowerInput.Text = string.Empty;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            car? selected = ListData.SelectedItem as car;   // ? -> povoluje hodnotu null
            if (selected != null)
            {
                Cars.Remove(selected);
            }
        }
    }
}