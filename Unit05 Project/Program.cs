/**
 * Class Program simulates a mini-ATM*/
internal class Program
{
  static void Main()
  {
    decimal balance = 1000m;
    string userChoice;

    do
    {
      Console.Write("Enter W for Withdraw\n" +
                    "Enter D for Deposit\n" +
                    "Enter B for Balance\n" +
                    "Enter E for Exit\n" +
                    "Choice: ");
      userChoice = Console.ReadLine().ToLower();

      switch (userChoice)
      {
        case "w":
          // User wants to withdraw money
          Console.Write("Enter amount to withdraw: $");
          decimal withdrawAmount = decimal.Parse(Console.ReadLine());

          // Check input
          if (withdrawAmount > balance) 
          {
            Console.WriteLine("Insufficient funds.");
            break;
          }
          else if (withdrawAmount <= 0)
          {
            Console.WriteLine("Improper withdraw amount entered.");
            break;
          }
          // Input is valid
          balance -= withdrawAmount;
          break;
        case "d":
          // User wants to withdraw money
          Console.Write("Enter amount to withdraw: $");
          decimal depositAmount = decimal.Parse(Console.ReadLine());

          // Check input
          if (depositAmount <= 0)
          {
            Console.WriteLine("Improper deposit amount entered.");
            break;
          }
          // Input is valid
          balance += depositAmount;
          break;
        case "b":
          Console.WriteLine($"Current balance: {balance:C}");
          break;
        case "e":
          Console.WriteLine("Thank you for banking with us!");
          break;
        default:
          Console.WriteLine("Choice not recognized.");
          break;
      };
      Console.WriteLine();
    } while (userChoice != "e");
  }
}