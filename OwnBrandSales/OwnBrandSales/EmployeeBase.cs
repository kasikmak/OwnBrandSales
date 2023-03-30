using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnBrandSales
{
    public abstract class EmployeeBase : IEmployee
    {
        public EmployeeBase(string name, string surname) 
        {
            this.Name = name;
            this.Surname = surname;
        }

        public delegate void HighRatioDelegate(object sender, EventArgs args);

        public virtual event HighRatioDelegate HighRatio;

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddNumberOfSales(int number);

        public abstract void AddNumberOfSales(string number);

        public abstract void AddValueOfSales(float value);

        public abstract void AddValueOfSales(string value);

        public abstract Calculations GetCalculations();
        
        public abstract void ShowCalculations();

        protected void HighRatioEvent()
        {
            if (HighRatio != null)
            {
               HighRatio(this, new EventArgs());
            }
        }
    }
}
