using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Customers> CustomersList;
        static Repository repository;
        IEditor editor;

        int _workerPost;

        public MainWindow()
        {
            InitializeComponent();
            _workerPost = 111;

            WorkerPostWindow workerPostWindow = new WorkerPostWindow(this);
            workerPostWindow.ShowDialog();

            if (_workerPost == 111)
            {
                this.Close();
            }

            repository = new Repository();

            if (editor.GetType() == typeof(Consultant))
            {
                CustomersList = repository.CustomersList;
                foreach (Customers customers in CustomersList)
                {
                    editor.CheckCustomer(customers);
                }
                listView.ItemsSource = CustomersList;
            }
            else
            {
                CustomersList = repository.CustomersList;
                listView.ItemsSource = CustomersList;
            }
        }

        private void AddNewCustomer(object sender, RoutedEventArgs e)
        {
            if (editor.GetType() == typeof(Manager))
            {
                var window = new NewCustomerWindow(this);

                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Недостаточно прав");
            }
        }
        public void SaveCustomers(string customer)
        {
            string [] customerArray =  customer.Split('#');

            Customers newCustomer = new Customers(int.Parse(customerArray[0]), 
                                                            customerArray[1], 
                                                            customerArray[2], 
                                                            customerArray[3], 
                                                            customerArray[4], 
                                                            customerArray[5]);

            repository.AddCustomer(newCustomer);
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            Customers customer = listView.SelectedItem as Customers;

            if(customer != null)
            {
                if (editor.GetType() == typeof(Consultant))
                {
                    Customers[] customersArray = repository.CreateCustomersArray();

                    for (int i = 0; i < customersArray.Length; i++)
                    {
                        if (customer.ID == customersArray[i].ID)
                        {
                            customer = customersArray[i];
                            break;
                        }
                    }
                }

                string editCustomer = string.Join("#",
                                          customer.ID.ToString(),
                                          customer.LastName,
                                          customer.FirstName,
                                          customer.MiddleName,
                                          customer.PhoneNumber,
                                          customer.Passport);

                EditCustomerWindow editCustomerWindow = new EditCustomerWindow(this,editCustomer, _workerPost);
                editCustomerWindow.ShowDialog();
            }
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            if(editor.GetType() == typeof(Manager))
            {
                Customers customer = listView.SelectedItem as Customers;

                if (customer != null)
                {
                    repository.DeleteCustomer(customer);
                    RefreshItems();
                }
            }
            else
            {
                MessageBox.Show("Недостаточно прав");
            }
        }

        public void WorkerPostChoice(int workerPost)
        {
            _workerPost = workerPost;

            if (_workerPost == 0)
            {
                WorkerPost.Text = "Консультант";
                editor = new Consultant();
            }
            else if (_workerPost == 1)
            {
                WorkerPost.Text = "Менеджер";
                editor = new Manager();
            }
            else
            {
                WorkerPost.Text = "Должность";
            }
        }

        public void RefreshItems()
        {
            if (editor.GetType() == typeof(Consultant))
            {
                repository.RefreshListItems();
                CustomersList = repository.CustomersList;
                foreach (Customers customers in CustomersList)
                {
                    editor.CheckCustomer(customers);
                }
            }
            else
            {
                repository.RefreshListItems();
            }
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            List<Customers> newList = CustomersList.ToList();

            newList.Sort(new Customers.SortByName());

            CustomersList.Clear();

            foreach (Customers customers in newList)
            {
                CustomersList.Add(customers);
            }
        }

        private void SortByID(object sender, RoutedEventArgs e)
        {
            List<Customers> newList = CustomersList.ToList();

            newList.Sort();

            CustomersList.Clear();

            foreach (Customers customers in newList)
            {
                CustomersList.Add(customers);
            }
        }
    }
}
