using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CurrencyConverterStatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BindCurrencyData();









        }


        private void BindCurrencyData()
        {

            DataTable dataTableCurrency = new DataTable();

            dataTableCurrency.Columns.Add("Text");
            dataTableCurrency.Columns.Add("Value");

            dataTableCurrency.Rows.Add("--Select--", 0);
            dataTableCurrency.Rows.Add("PLN", 1);
            dataTableCurrency.Rows.Add("EUR", 3);
            dataTableCurrency.Rows.Add("USD", 7);


            comboboxFromCurrency.ItemsSource = dataTableCurrency.DefaultView;
            comboboxFromCurrency.DisplayMemberPath = "Text";
            comboboxFromCurrency.SelectedValuePath = "Value";
            comboboxFromCurrency.SelectedIndex = 0;

            comboboxToCurrency.ItemsSource = dataTableCurrency.DefaultView;
            comboboxToCurrency.DisplayMemberPath = "Text";
            comboboxToCurrency.SelectedValuePath = "Value";
            comboboxToCurrency.SelectedIndex = 0;
        }



        //Allow only the integer value in TextBox
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            if (textCurrency.Text == null || textCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                textCurrency.Focus();
                return;
            }

            else if (comboboxFromCurrency.SelectedValue == null || comboboxFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select From Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                comboboxFromCurrency.Focus();
                return;
            }

            else if (comboboxToCurrency.SelectedValue == null || comboboxToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select To Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                comboboxToCurrency.Focus();
                return;
            }



            if (comboboxFromCurrency.Text == comboboxToCurrency.Text)
            {
                ConvertedValue = double.Parse(textCurrency.Text);

                labelCurrency.Content = comboboxToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                ConvertedValue = (double.Parse(comboboxFromCurrency.SelectedValue.ToString()) * double.Parse(textCurrency.Text)) / double.Parse(comboboxToCurrency.SelectedValue.ToString());

                labelCurrency.Content = comboboxToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }

        }



        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            textCurrency.Text = string.Empty;

            if (comboboxFromCurrency.Items.Count > 0)
                comboboxFromCurrency.SelectedIndex = 0;

            if (comboboxToCurrency.Items.Count > 0)
                comboboxToCurrency.SelectedIndex = 0;

            labelCurrency.Content = "";
            textCurrency.Focus();
        }


















    }

}
