using System.Windows;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        MainWindow mainWindow;

        public NewCustomerWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void AddNewCustomer(object sender, RoutedEventArgs e)
        {
             string customer = string.Join("#",
                                          "0",
                                          LastName.Text,
                                          FirstName.Text,
                                          MiddleName.Text,
                                          PhoneNumber.Text,
                                          Passport.Text);

            mainWindow.SaveCustomers(customer);
            this.Close();
        }
    }
}
