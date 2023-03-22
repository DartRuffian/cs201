/**
 * @author William Grate
 */
internal class Program
{
  static void Main(string[] args)
  {
    var randomGenerator = new Random();
    int randomNum = randomGenerator.Next(600001);
    Console.WriteLine($"Income tax rate for {randomNum:C}: " +
      $"{GetIncomeTaxRate(randomNum)}%");
  }

  /**
   * GetIncomeTaxRate determines the US federal income tax rate for a given
   * income.
   * @param income The income in US dollars
   * @precondition income >= 0
   * @return The tax rate
   */
  static int GetIncomeTaxRate(int income)
  {
    int tax_rate;

    switch (income)
    {
      case <= 9875:
        tax_rate = 10;
        break;
      case <= 40125:
        tax_rate = 12;
        break;
      case <= 85525:
        tax_rate = 22;
        break;
      case <= 163300:
        tax_rate = 24;
        break;
      case <= 207350:
        tax_rate = 32;
        break;
      case <= 518400:
        tax_rate = 35;
        break;
      case >= 518401:
        tax_rate = 37;
        break;
    }
    return tax_rate;
  }
}