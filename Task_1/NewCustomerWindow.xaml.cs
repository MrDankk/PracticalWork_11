using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        Repository repository;

        public NewCustomerWindow()
        {
            InitializeComponent();
        }

        private void AddNewCustomer(object sender, RoutedEventArgs e)
        {
            repository = Repository.CreateRepository();

            Customers customer = new Customers(0 , LastName.Text, FirstName.Text,MiddleName.Text,PhoneNumber.Text,Passport.Text);

            repository.AddCustomer(customer);

            NewCustomerWindow newCustomerWindow = this;
            newCustomerWindow.Close();
        }
    }
}
