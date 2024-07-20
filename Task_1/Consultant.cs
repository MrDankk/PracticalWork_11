using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Consultant : IEditor
    {
        private string tempPassport;

        public void SaveChanges(Customers customer,
                                string editFirstName,
                                string editLastName,
                                string editMiddleName,
                                string editPhoneNumber,
                                string editPassport)
        {
            Customers editCustomer = customer;

            editCustomer.PhoneNumber = editPhoneNumber;
            editCustomer.Passport = tempPassport;

            Repository repository = new Repository();

            repository.ApplyChanges(editCustomer);
        }

        public Customers CheckCustomer(Customers customer)
        {
            tempPassport = customer.Passport;

            customer.Passport = Censorship(customer.Passport);

            return customer;
        }

        public string Censorship(string original)
        {
            char[] originalCharArr = original.ToCharArray();

            for (int i = 0; i < originalCharArr.Length; i++)
            {
                originalCharArr[i] = '*';
            }

            string censorship = new string(originalCharArr);

            return censorship;
        }
    }
}
