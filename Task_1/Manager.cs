using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Manager : Worker
    {
        /// <summary>
        /// Приветствие
        /// </summary>
        public override void Greeting()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте менеджер, вам доступны все функции.");
        }
    }
}
