using OwnBrandSales;

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Hello, Welcome to application monitoring the sales of their own brand products.");
Console.WriteLine("---------------------------------------------------");

bool ExitApp = false;

while (!ExitApp)
{
    Console.WriteLine("You have following options:");
    Console.WriteLine("1 - to keep data in program memory");
    Console.WriteLine("2 - to keep data in seprate files for each employee");
    Console.WriteLine("X - to exit application");

    Console.WriteLine("You have to choose what to do\nPress 1, 2 or X");
    Console.ResetColor();
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddDataToMemory();
            break;
        case "2":
            AddDataToFiles();
            break;
        case "x" or "X":
            ExitApp = true;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wrong data. You have to type 1,2 or x");
            Console.ResetColor();
            continue;
    }
}

void EmployeeHighRatio(object sender, EventArgs e)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Impressive result! Keep going and you might qualify for a rise.");
    Console.ResetColor();
}

void AddDataToFiles()
{
    Console.WriteLine("Enter employee's first name");
    string name = Console.ReadLine();
    string firstName = name.ToUpper();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    string lastName = surname.ToUpper();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInFile = new EmployeeInFile(firstName, lastName);
        employeeInFile.HighRatio += EmployeeHighRatio;
        EnterNumber(employeeInFile);
        EnterValue(employeeInFile);
        employeeInFile.GetCalculations();
        employeeInFile.ShowCalculations();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have to enter employee's name and surname");
        Console.ResetColor();
    }
}

void AddDataToMemory()
{
    Console.WriteLine("Enter employee's first name");
    string name = Console.ReadLine();
    string firstName = name.ToUpper();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    string lastName = surname.ToUpper();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInMemory = new EmployeeInMemory(firstName, lastName);
        employeeInMemory.HighRatio += EmployeeHighRatio;
        EnterNumber(employeeInMemory);
        EnterValue(employeeInMemory);
        employeeInMemory.GetCalculations();
        employeeInMemory.ShowCalculations();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have to enter employee's name and surname");
        Console.ResetColor();
    }
}
void EnterNumber(IEmployee employee)
{
    while (true)
    {
        Console.WriteLine($"Enter number of daily sales for {employee.Name} {employee.Surname} and then to continue enter q");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            employee.AddNumberOfSales(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine();
        }
    }
}

void EnterValue(IEmployee employee)
{
    while (true)
    {
        Console.WriteLine($"Enter value of daily sales for {employee.Name} {employee.Surname} and then to continue enter q");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            employee.AddValueOfSales(input);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
}