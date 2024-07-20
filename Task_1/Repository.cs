using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Task_1
{
    class Repository
    {
        private string customersPath;
        private string changesPath;

        /// <summary>
        /// Выбор пути к файлу клиентов
        /// </summary>
        public string CustomersPath
        {
            set { this.customersPath = value; }
            get { return this.customersPath; }
        }

        /// <summary>
        /// Выбор пути к файлу изменений
        /// </summary>
        public string ChangesPath
        {
            set { this.changesPath = value; }
            get { return this.changesPath; }
        }

        public ObservableCollection<Customers> CustomersList { get; set; }
        public Repository()
        {
            CustomersPath = "Customers.txt";
            ChangesPath = "CustomersEdit.txt";

            CustomersList = new ObservableCollection<Customers>();

            Customers[] customers = CreateCustomersArray();

            for (int i = 0; i < customers.Length; i++)
            {
                CustomersList.Add (customers[i]);
            }
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="worker"></param>
        public void AddCustomer(Customers customer)
        {
            CustomersList.Add(customer);

            customer.ID = ArrayLength(customersPath);

            string line = string.Join("#",
                                      customer.ID,
                                      customer.LastName,
                                      customer.FirstName,
                                      customer.MiddleName,
                                      customer.PhoneNumber,
                                      customer.Passport);
            using (StreamWriter streamWriter = new StreamWriter(customersPath, true))
            {
                if (line != "")
                {
                    streamWriter.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Создание массива клиентов
        /// </summary>
        /// <returns></returns>
        public Customers[] CreateCustomersArray()
        {
            int length = ArrayLength(customersPath);
            Customers[] customer = new Customers[length];

            using (StreamReader streamReader = new StreamReader(customersPath))
            {
                string line;
                int currentIndex = 0;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] dataArray = line.Split('#');

                    customer[currentIndex] = new Customers(int.Parse(dataArray[0]), dataArray[1], dataArray[2], dataArray[3], dataArray[4], dataArray[5]);

                    currentIndex++;
                }
            }
            return customer;
        }

        public void RefreshListItems()
        {
            CustomersList.Clear();

            Customers[] customers = CreateCustomersArray();

            for (int i = 0; i < customers.Length; i++)
            {
                CustomersList.Add(customers[i]);
            }
        }

        public void ApplyChanges(Customers editCustomer)
        {
            Customers[] customersArray = CreateCustomersArray();

            for (int i = 0; i < customersArray.Length; i++)
            {
                if(editCustomer.ID == customersArray[i].ID)
                {
                    customersArray[i] = editCustomer;
                    break;
                }
            }

            File.Delete(customersPath);

            for (int i = 0;i < customersArray.Length; i++)
            {
                AddCustomer(customersArray[i]);
            }
        }

        public void DeleteCustomer(Customers deleteCustomer)
        {
            Customers[] customersArray = CreateCustomersArray();
            Customers[] tempCustomersArray = new Customers[customersArray.Length - 1];

            bool find = false;

            for (int i = 0; i < tempCustomersArray.Length; i++)
            {
                if (deleteCustomer.ID != customersArray[i].ID && !find)
                {
                    tempCustomersArray[i] = customersArray[i];
                }
                else if(find)
                {
                    tempCustomersArray[i] = customersArray[i + 1];
                }
                else
                {
                    find = true;
                    tempCustomersArray[i] = customersArray[i + 1];
                }
            }

            File.Delete(customersPath);

            for(int i = 0; i < tempCustomersArray.Length; i++)
            {
                AddCustomer(tempCustomersArray[i]);
            }
        }

        /// <summary>
        /// Проверка количества строк в файле и установка длины массива
        /// </summary>
        /// <returns></returns>
        private int ArrayLength(string path)
        {
            FileChecking(path);
            int length = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    length++;
                }
            }
            return length;
        }

        /// <summary>
        /// Проверка наличия файла
        /// </summary>
        private void FileChecking(string path)
        {
            if (!File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                fileStream.Close();
            }
        }
    }
}
