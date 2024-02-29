string fullName = "";
string username = "";
string password = "";
double accountBalance = 200000.00; 
int[] accountNumber = new int[10]; 
Console.BackgroundColor = ConsoleColor.DarkMagenta;

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Welcome to the Bank App!");
Console.ForegroundColor = ConsoleColor.DarkBlue;

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Log In");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            CreateAccount();
            break;
        case 2:
            if (LogIn())
                BankOperations();
            break;
        case 3:
            Console.WriteLine("Exiting the Bank App. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}


void CreateAccount()
{
    Console.WriteLine("\nCreate Account:");
    Console.Write("Enter your full name: ");
    fullName = Console.ReadLine();
    Console.Write("Enter a username: ");
    username = Console.ReadLine();
    Console.Write("Create a password: ");
    password = Console.ReadLine();
    GenerateAccountNumber(); 

    Console.WriteLine("Account created successfully!");
    Console.WriteLine($"Your account number is: {string.Join("", accountNumber)}");
}

bool LogIn()
{
    Console.WriteLine("\nLog In:");
    Console.Write("Enter your username: ");
    string inputUsername = Console.ReadLine();
    Console.Write("Enter your password: ");
    string inputPassword = Console.ReadLine();

    if (inputUsername == username && inputPassword == password)
    {
        Console.WriteLine("Log in successful. Welcome, " + fullName + "!");
        return true;
    }
    else
    {
        Console.WriteLine("Invalid username or password. Please try again.");
        return false;
    }
}

void BankOperations()
{
    while (true)
    {
        Console.WriteLine("\nBank Operations:");
        Console.WriteLine("1. Check Account Balance");
        Console.WriteLine("2. Withdraw Money");
        Console.WriteLine("3. Transfer Money");
        Console.WriteLine("4. Log Out");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CheckAccountBalance();
                break;
            case 2:
                WithdrawMoney();
                break;
            case 3:
                TransferMoney();
                break;
            case 4:
                Console.WriteLine("Logging out. Goodbye, " + fullName + "!");
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void CheckAccountBalance()
{
    Console.WriteLine("\nAccount Balance: $" + accountBalance);
}

void WithdrawMoney()
{
    Console.Write("\nEnter the amount to withdraw: $");
    double amount = double.Parse(Console.ReadLine());
    if (amount <= accountBalance || accountBalance >= 50000)
    {
        accountBalance -= amount;
        Console.WriteLine("Withdrawal successful. Remaining balance: $" + accountBalance);
    }
    else
    {
        Console.WriteLine("Insufficient balance. Withdrawal failed.");
    }
}

void TransferMoney()
{
    Console.Write("\nEnter the amount to transfer: $");
    double amount = double.Parse(Console.ReadLine());
    if (amount <= accountBalance || accountBalance >= 50000)
    {
        Console.Write("Enter the recipient's username: ");
        string recipientUsername = Console.ReadLine();
        Console.WriteLine($"You have transferred ${amount} to {recipientUsername}.");
        accountBalance -= amount;
        Console.WriteLine("Remaining balance: $" + accountBalance);
    }
    else
    {
        Console.WriteLine("Insufficient balance. Transfer failed.");
    }
}

void GenerateAccountNumber()
{
    Random random = new Random();
    for (int i = 0; i < accountNumber.Length; i++)
    {
        accountNumber[i] = random.Next(10);
    }
}

