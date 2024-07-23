using System.Windows;
using System.Windows.Media;

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
            if(CheckEmptyInput())
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
            else
            {
                CheckEmptyPosition();
            }
        }

        private bool CheckEmptyInput()
        {
            bool check = false;

            if(LastName.Text.Trim() != ""&&
               FirstName.Text.Trim() != "" &&
               MiddleName.Text.Trim() != ""&&
               PhoneNumber.Text.Trim() != "" &&
               Passport.Text.Trim() != "")
            {
                check = true;
            }

            return check;
        }


        private void CheckEmptyPosition()
        {
            if(LastName.Text.Trim() == "")
            {
                LastName.Background = Brushes.Red;
            }else{
                LastName.Background = Brushes.White;
            }

            if (FirstName.Text.Trim() == "")
            {
                FirstName.Background = Brushes.Red;
            }else{
                FirstName.Background = Brushes.White;
            }

            if (MiddleName.Text.Trim() == "")
            {
                MiddleName.Background = Brushes.Red;
            }else{
                MiddleName.Background= Brushes.White;
            }

            if (PhoneNumber.Text.Trim() == "")
            {
                PhoneNumber.Background = Brushes.Red;
            }else{
                PhoneNumber.Background= Brushes.White;
            }

            if (Passport.Text.Trim() == "")
            {
                Passport.Background = Brushes.Red;
            }else{
                Passport.Background= Brushes.White;
            }
        }
    }
}
