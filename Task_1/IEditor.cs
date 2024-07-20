using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal interface IEditor
    {
        Customers CheckCustomer(Customers customer);
        void SaveChanges(Customers customer,
                                string editFirstName,
                                string editLastName,
                                string editMiddleName,
                                string editPhoneNumber,
                                string editPassport);
    }
}
