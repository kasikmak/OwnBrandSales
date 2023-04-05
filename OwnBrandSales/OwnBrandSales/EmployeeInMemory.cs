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

        public override void AddNumberOfSales(int number)
        {
            if (number >= 0)
            {
                numbers.Add(number);
            }
            else
            {
                throw new ArgumentException ("Only enter if there were any sales");
            }
        }

        public override void AddNumberOfSales(string number)
        {
            if (int.TryParse(number, out int result))
            {
                this.AddNumberOfSales(result);
            }
            else
            {
                throw new FormatException ("You have to write a whole number.");
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
                throw new ArgumentException("Only enter if there were any sales.");
            }
        }

        public override void AddValueOfSales(string value)
        {
            if (float.TryParse(value, out float result))
            {
                this.AddValueOfSales(result);
            }
            else
            {
                throw new FormatException("You have to write a whole number.");
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
    }
}

