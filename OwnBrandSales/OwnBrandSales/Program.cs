using OwnBrandSales;

WriteInColor(ConsoleColor.DarkCyan, "Hello, Welcome to application monitoring the sales of their own brand products.");
Console.WriteLine("---------------------------------------------------");

bool ExitApp = false;

while (!ExitApp)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
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
            WriteInColor(ConsoleColor.DarkRed, "Wrong data. You have to type 1,2 or x");
            continue;
    }
}

void EmployeeHighRatio(object sender, EventArgs e)
{
    WriteInColor(ConsoleColor.Green, "Impressive result! Keep going and you might qualify for a rise.");
}

void AddDataToFiles()
{
    Console.WriteLine("Enter employee's first name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInFile = new EmployeeInFile(name, surname);
        employeeInFile.HighRatio += EmployeeHighRatio;
        EnterNumber(employeeInFile);
        EnterValue(employeeInFile);
        employeeInFile.GetCalculations();
        employeeInFile.ShowCalculations();
    }
    else
    {
        WriteInColor(ConsoleColor.DarkRed, "You have to enter employee's name and surname");
    }
}

void AddDataToMemory()
{
    Console.WriteLine("Enter employee's first name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInMemory = new EmployeeInMemory(name, surname);
        employeeInMemory.HighRatio += EmployeeHighRatio;
        EnterNumber(employeeInMemory);
        EnterValue(employeeInMemory);
        employeeInMemory.GetCalculations();
        employeeInMemory.ShowCalculations();
    }
    else
    {
        WriteInColor(ConsoleColor.DarkRed, "You have to enter employee's name and surname");
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
        catch (ArgumentException e)
        {
            WriteInColor(ConsoleColor.DarkCyan, $"{e.Message}");
        }
        catch (FormatException e)
        {
            WriteInColor(ConsoleColor.DarkYellow, e.Message);
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
        catch (ArgumentException e)
        {
            WriteInColor(ConsoleColor.DarkCyan, $"{e.Message}");
        }
        catch(FormatException e)
        {
            WriteInColor(ConsoleColor.DarkYellow, e.Message);
        }

    }
}
static void WriteInColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}