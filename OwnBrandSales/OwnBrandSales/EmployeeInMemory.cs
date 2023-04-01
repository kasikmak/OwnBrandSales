namespace OwnBrandSales
{
    public class EmployeeInMemory : EmployeeBase
    {
        public EmployeeInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        private List<int> numbers = new List<int>();

        private List<float> values = new List<float>();

        public override event HighRatioDelegate HighRatio;

        public override void AddNumberOfSales(int number)
        {
            if (number >= 0)
            {
                numbers.Add(number);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Only enter if there were any sales");
                Console.ResetColor();
            }
        }

        public override void AddNumberOfSales(string number)
        {
            if (int.TryParse(number, out int result))
            {
                numbers.Add(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You have to write a whole number.");
                Console.ResetColor();
            }
        }


        public override void AddValueOfSales(float value)
        {
            if (value >= 0)
            {
                values.Add(value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Only enter if there were any sales.");
                Console.ResetColor();
            }
        }

        public override void AddValueOfSales(string value)
        {
            if (float.TryParse(value, out float result))
            {
                values.Add(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You have to write a number.");
                Console.ResetColor();
            }
        }


        public override Calculations GetCalculations()
        {
            var calculations = new Calculations();
            foreach (var number in numbers)
            {
                calculations.GetNumberSum(number);
            }
            foreach (var value in values)
            {
                calculations.GetValueSum(value);
            }
            calculations.GetResult();
            return calculations;
        }

        public override void ShowCalculations()
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
    }
}

