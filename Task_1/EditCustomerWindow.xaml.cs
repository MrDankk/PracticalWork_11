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
    /// Логика взаимодействия для EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        MainWindow MainWindow;
        Customers editCustomer;
        IEditor editor;

        public EditCustomerWindow(MainWindow mainWindow,string customer,int workerPost)
        {
            InitializeComponent();
            MainWindow = mainWindow;

            string[] customerArray = customer.Split('#');

            editCustomer = new Customers(int.Parse(customerArray[0]),
                                                            customerArray[1],
                                                            customerArray[2],
                                                            customerArray[3],
                                                            customerArray[4],
                                                            customerArray[5]);

            if(workerPost == 1)
            {
                editor = new Manager();
            }
            else
            {
                editor = new Consultant();

                EditFirstName.IsEnabled = false;
                EditLastName.IsEnabled = false;
                EditMiddleName.IsEnabled = false;
                EditPassport.IsEnabled = false;
            }

            editCustomer = editor.CheckCustomer(editCustomer);

            EditFirstName.Text = editCustomer.FirstName;
            EditLastName.Text = editCustomer.LastName;
            EditMiddleName.Text = editCustomer.MiddleName;
            EditPassport.Text = editCustomer.Passport;
            EditPhoneNumber.Text = editCustomer.PhoneNumber;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            editor.SaveChanges(editCustomer, EditFirstName.Text, EditLastName.Text, EditMiddleName.Text, EditPhoneNumber.Text, EditPassport.Text);
            MainWindow.RefreshItems();
            this.Close();
        }

    }
}
