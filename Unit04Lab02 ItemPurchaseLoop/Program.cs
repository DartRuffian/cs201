/**
 * @author William Grate
 * Class Program retrieves money entered for a vending machine item until
 * enough money is entered.*/
internal class Program
{
  static void Main()
  {
    // Prompt the user for the cost of the item
    Console.Write("Vending machine item cost: $");
    decimal itemCost = Decimal.Parse(Console.ReadLine());

    decimal totalPayed = 0.0m;

    totalPayed += GetPayment("Please deposit money: $",
                             itemCost - totalPayed);

    while (totalPayed <= itemCost)
    {
      Console.WriteLine($"{itemCost - totalPayed:C} still needed.");
      totalPayed += GetPayment("Deposit additional money: $",
                               itemCost - totalPayed);
    };

    Console.WriteLine("Please take your item.");
    if (totalPayed > itemCost) Console.WriteLine("Please take your change " +
      $"of {totalPayed - itemCost:C}");
  }

  static decimal GetPayment(string message, decimal balance)
  {
    while (true)
    {
      Console.Write(message);
      decimal currentPayment = Decimal.Parse(Console.ReadLine());
      Console.WriteLine();

      if (currentPayment > 0) return currentPayment;
      else
      {
        Console.WriteLine($"{balance:C} still needed.");
        continue;
      }
    };
  }
}