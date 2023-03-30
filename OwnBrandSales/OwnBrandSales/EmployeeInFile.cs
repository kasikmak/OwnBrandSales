using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public override event HighRatioDelegate HighRatio;

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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Only enter if there were any sales.");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                throw new Exception("You have to write a whole number.");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Only enter if there were any sales.");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                throw new Exception("You have to write a number.");
                Console.ResetColor();
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

        public override void ShowCalculations()
        {
            var calc = GetCalculations();
            if (calc != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();
                Console.WriteLine($"{Name} {Surname}'s result is {calc.Result:N2} which translates to {calc.Ratio}.\nTotal number of sales: {calc.NumberSum} and total value of sales: {calc.ValueSum}\n");
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
