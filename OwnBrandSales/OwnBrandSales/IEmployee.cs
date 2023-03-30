using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnBrandSales
{
    interface IEmployee
    {
        string Name { get; }
        string Surname { get; }

        public void AddNumberOfSales(int number);

        public void AddNumberOfSales(string number);

        public void AddValueOfSales(float value);

        public void AddValueOfSales(string value);

        public Calculations GetCalculations();



    }
}
