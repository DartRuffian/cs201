
using System.Diagnostics.Metrics;
/**
 * @author William Grate
 * Class Program will compute the tax owed on a purchase in several states*/
internal class Program
{
  static void Main()
  {
    // Prompt the user for the total
    Console.Write("Purchase price: $");
    decimal total = decimal.Parse(Console.ReadLine());

    // Prompt the user for the state code
    Console.Write("Two letter abbreviation of state where purchased: ");
    string state = Console.ReadLine();

    // Determine the tax amount based on the state
    double tax = 0;
    switch (state.ToLower())
    {
      case "mo":
        tax = 0.04225;
        break;
      case "ks":
        tax = 0.065;
        break;
      case "ne":
        tax = 0.055;
        break;
      case "ia":
        tax = 0.06;
        break;

      default:
        Console.WriteLine("I'm sorry, that state is not in our system.");
        return;
    }

    decimal total_tax = total *= (decimal)tax;

    Console.WriteLine($"Sales Tax: {total_tax:C2}");
  }
}