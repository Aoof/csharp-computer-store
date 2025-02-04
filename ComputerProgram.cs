// Github Repo: https://github.com/aoof/csharp-computer-store
class Computer {
    private string brand;
    private string model;
    private long SN;
    private double price;

    private static int count = 0;
    public Computer() {
        brand = "Unknown";
        model = "Unknown";
        SN = 0;
        price = 0.0;
        count++;
    }

    public Computer(string brand, string model, long SN, double price) {
        this.brand = brand;
        this.model = model;
        this.SN = SN;
        this.price = price;
        count++;
    }

    public Computer(Computer computer) {
        brand = computer.brand;
        model = computer.model;
        SN = computer.SN;
        price = computer.price;
        count++;
    }

    public string Brand {
        get { return brand; }
        set { brand = value; }
    }

    public string Model {
        get { return model; }
        set { model = value; }
    }

    public long SerialNumber {
        get { return SN; }
        set { SN = value; }
    }

    public double Price {
        get { return price; }
        set { price = value; }
    }

    public override string ToString() {
        return "Brand: " + brand + "\nModel: " + model + "\nSerial Number: " + SN + "\nPrice: " + price;
    }

    public static int findNumberOfCreatedinventory() {
        return count;
    }
}

class ComputerProgram {

    private const string PASSWORD = "password";
    private const int MAX_ATTEMPTS = 3;
    private static Computer[] inventory = new Computer[0];
    private static int availableSpace = 0;
    private static bool loggedIn = false;
    private static int failedAttempts = 0;

    private static int inventorySize {
        get { return Computer.findNumberOfCreatedinventory(); }
    }

    static void Main() {
        Console.WriteLine("Welcome to the Computer Store!");

        Console.Write("Please enter the capacity of your inventory: ");
        int n = Convert.ToInt32(Console.ReadLine());

        inventory = new Computer[n];
        availableSpace = n;

        ShowMenu();
    }

    static void ShowMenu() {
        int choice; 
        do {
            Console.WriteLine("\n1. Add a computer to inventory");
            Console.WriteLine("2. Update a computer in inventory");
            Console.WriteLine("3. Display all computers of a brand");
            Console.WriteLine("4. Display all computers with a price less than a given value");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5) {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }

            switch (choice) {
                case 1:
                    AddComputers();
                    break;
                case 2:
                    UpdateComputer();
                    break;
                case 3:
                    DisplayBrandComputers(); 
                    break;
                case 4:
                    DisplayFilteredComputers();
                    break;
                case 5:
                    return;
                default:
                    break;
            }
        } while (choice != 5);
    }

    static bool Authenticate()
    {
        if (loggedIn) return true;

        while (failedAttempts < MAX_ATTEMPTS)
        {
            // Get the password in a secure way
            Console.Write("Please enter your password: ");
            string password = string.Empty;
            ConsoleKey key;
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();

            if (password == PASSWORD)
            {
                loggedIn = true;
                return true;
            } else {
                Console.WriteLine("Invalid password. Please try again.");
                failedAttempts++;
            } 
        }

        Console.WriteLine("You have exceeded the maximum number of attempts. Please try again later.");
        failedAttempts = 0;

        Console.TreatControlCAsInput = false;

        return false;
    }

    static void AddComputers(int n = -1)
    {
        if (!Authenticate()) return;

        if (n == -1)
        {
            Console.Write("Please enter the amount of computers you'd like to enter: ");
            n = Convert.ToInt32(Console.ReadLine());
        }

        if (availableSpace < n || n < 0)
        {
            Console.WriteLine($"You cannot add that many computers as your storage only allows {availableSpace} more computers.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Computer # {inventory.Length - availableSpace}");
            
            int currentIndex = inventory.Length - availableSpace;
            Computer currentComputer = inventory[currentIndex] = new Computer();

            Console.Write("Please enter the brand name of this computer: ");
            currentComputer.Brand = Console.ReadLine() ?? "Unknown";

            Console.Write("Please enter the model of this computer: ");
            currentComputer.Model = Console.ReadLine() ?? "Unknown";

            Console.Write("Please enter the price of this computer: ");
            currentComputer.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter the serial number of this computer: ");
            currentComputer.SerialNumber = long.Parse(Console.ReadLine() ?? "0");

            availableSpace--;
        }
    }

    static void UpdateComputer()
    {
        if (!Authenticate()) return;

        Console.Write("Please enter the computer index: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n > inventorySize || n < 0)
        {
            Console.WriteLine("Would you like to add a new computer to your inventory? (Y/n): ");

            char choice = (Console.ReadLine() ?? "Y")[0];
            if (char.ToLower(choice) == 'y') AddComputers(1);
            return;
        }

        Computer currentComputer = inventory[n]; 
        while (true)
        {
            Console.WriteLine(
                    $"\nComputer # {n}\n" +
                    $"Brand: {currentComputer.Brand}\n" +
                    $"Model: {currentComputer.Model}\n" +
                    $"Serial Number: {currentComputer.SerialNumber}\n" +
                    $"Price: {currentComputer.Price}\n" 
                );
        
            Console.WriteLine("What information would you like to change?");
            Console.WriteLine("1. Brand");
            Console.WriteLine("2. Model");
            Console.WriteLine("3. Serial Number");
            Console.WriteLine("4. Price");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice;

            switch (int.TryParse(Console.ReadLine(), out choice) ? choice : 0)
            {
                case 1:
                    Console.Write("Please enter the new brand name: ");
                    currentComputer.Brand = Console.ReadLine() ?? "Unknown";
                    break;
                case 2:
                    Console.Write("Please enter the new model name: ");
                    currentComputer.Model = Console.ReadLine() ?? "Unknown";
                    break;
                case 3:
                    Console.Write("Please enter the new serial number: ");
                    currentComputer.SerialNumber = long.Parse(Console.ReadLine() ?? "0");
                    break;
                case 4:
                    Console.Write("Please enter the new price: ");
                    currentComputer.Price = double.Parse(Console.ReadLine() ?? "0");
                    break;
                case 5:
                    return;
                default:
                    break;
            }

            Console.WriteLine("Computer updated successfully!");
        }
    }

    static void DisplayBrandComputers()
    {
        Console.Write("Please enter the brand name: ");
        string brand = Console.ReadLine() ?? "Unknown";

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].Brand == brand)
            {
                Console.WriteLine("\nComputer # " + i);
                Console.WriteLine(inventory[i]);
            }
        }
    }

    static void DisplayFilteredComputers()
    {
        Console.Write("Please enter the maximum price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].Price < price)
            {
                Console.WriteLine("\nComputer # " + i);
                Console.WriteLine(inventory[i]);
            }
        }
    }
}