using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Manager : IEditor
    {
        public void SaveChanges(Customers customer,
                                string editFirstName,
                                string editLastName,
                                string editMiddleName,
                                string editPhoneNumber,
                                string editPassport)
        {
            Customers editCustomer = customer;

            editCustomer.FirstName = editFirstName;
            editCustomer.LastName = editLastName;
            editCustomer.MiddleName = editMiddleName;
            editCustomer.PhoneNumber = editPhoneNumber;
            editCustomer.Passport = editPassport;

            Repository repository = new Repository();

            repository.ApplyChanges(editCustomer);
        }

        public Customers CheckCustomer(Customers customer)
        {
            return customer;
        }
    }
}
