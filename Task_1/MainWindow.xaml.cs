﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;

        public MainWindow()
        {
            repository = Repository.CreateRepository();

            listView.ItemsSource = repository.CustomersList;

            InitializeComponent();
        }

        private void AddNewCustomer(object sender, RoutedEventArgs e)
        {
            var window = new NewCustomerWindow();

            window.ShowDialog();
        }

        private void RefreshItems(object sender, RoutedEventArgs e)
        {
            listView.Items.Refresh();
        }
    }
}
