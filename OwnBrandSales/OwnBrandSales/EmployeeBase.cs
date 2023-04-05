namespace OwnBrandSales
{
    public abstract class EmployeeBase : IEmployee
    {
        public EmployeeBase(string name, string surname) 
        {
            this.Name = name.ToUpper();
            this.Surname = surname.ToUpper();
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
        
        public void ShowCalculations()
        {
            var calc = GetCalculations();
            if (calc != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();
                Console.WriteLine($"{Name} {Surname}'s result is {calc.Result:N2} which translates to ratio of {calc.Ratio}.\nTotal number of sales: {calc.NumberSum} and total value of sales: {calc.ValueSum}\n");
                Console.ResetColor();
                if (calc.Ratio >= 1.1)
                {
                    HighRatioEvent();
                }
            }
            else
            {
                Console.WriteLine($"No sales recorded for {Name} {Surname}.");
            }
            Console.WriteLine("------------------------------------------------------------------------");
        }

        protected void HighRatioEvent()
        {
            if (HighRatio != null)
            {
               HighRatio(this, new EventArgs());
            }
        }
    }
}
