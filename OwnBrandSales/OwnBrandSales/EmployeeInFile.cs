namespace OwnBrandSales
{
    internal class EmployeeInFile : EmployeeBase
    {
        private string fileName = "Sales.txt";
        private string fileNameEmployeeNumber;
        private string fileNameEmployeeValue;


        public EmployeeInFile(string firstName, string lastName)
            : base(firstName, lastName)
        {
            fileNameEmployeeNumber = $"{firstName}_{lastName}_Number{fileName}.txt";
            fileNameEmployeeValue = $"{firstName}_{lastName}_Value{fileName}.txt";
        }

        public override void AddNumberOfSales(int number)
        {
            if (number >= 0)
            {
                using (var writer = File.AppendText(fileNameEmployeeNumber))
                {
                    writer.WriteLine(number);
                }
            }
            else
            {
                throw new ArgumentException("Only enter if there were any sales.");
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
                throw new FormatException("You have to write a whole number.");
            }
        }

        public override void AddValueOfSales(float value)
        {
            if (value >= 0)
            {
                using (var writer = File.AppendText(fileNameEmployeeValue))
                {
                    writer.WriteLine(value);
                }
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
                throw new FormatException("You have to write a number.");
            }
        }



        public override Calculations GetCalculations()
        {
            var calculations = new Calculations();
            var numbers = new List<int>();
            if (File.Exists(fileNameEmployeeNumber))
            {
                using (var reader = File.OpenText(fileNameEmployeeNumber))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = int.Parse(line);
                        calculations.GetNumberSum(number);
                        line = reader.ReadLine();
                    }
                }
            }
            var values = new List<float>();
            if (File.Exists(fileNameEmployeeValue))
            {
                using (var reader = File.OpenText(fileNameEmployeeValue))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var value = float.Parse(line);
                        calculations.GetValueSum(value);
                        line = reader.ReadLine();
                    }
                }
            }
            calculations.GetResult();
            return calculations;
        }        
    }
}
