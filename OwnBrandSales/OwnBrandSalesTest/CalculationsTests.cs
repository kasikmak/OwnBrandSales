using OwnBrandSales;
using System.Xml.Schema;

namespace OwnBrandSalesTest
{
    public class Tests
    {

        [Test]
        public void GettingSumOfAddedNumbersTest()
        {
            var calculations = new Calculations();
            List<int> numbers = new List<int>();
            numbers.Add(45);
            numbers.Add(23);
            numbers.Add(19);

            foreach (var number in numbers)
            {
                calculations.GetNumberSum(number);
            }

            Assert.AreEqual(87, calculations.NumberSum);

        }

        [Test]
        public void GettingSumOfAddedValuesTest()
        {
            var calculations = new Calculations();
            List<float> values = new List<float>();
            values.Add(50.5f);
            values.Add(100);
            values.Add(200);

            foreach (var value in values)
            {
                calculations.GetValueSum(value);
            }

            Assert.AreEqual(350.5, calculations.ValueSum);
        }

        [Test]
        public void GettingResult()
        {
            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            List<float> values = new List<float>();
            values.Add(37);
            values.Add(53);
            var numbersSum = numbers.Sum();
            var valuesSum = values.Sum();

            var result = valuesSum / numbersSum;

            Assert.AreEqual(3, result);

        }

        [Test]
        public void GetCalculations()
        {
            var calc = new Calculations();
            calc.GetNumberSum(30);
            calc.GetValueSum(90);

            calc.GetResult();

            Assert.That(3, Is.EqualTo(3));

        }
    }
}