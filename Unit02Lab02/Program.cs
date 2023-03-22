/**
 * @author William Grate
 * Class Program prompts the user for two integers and displays simple
 * calculations, such as addition; subtraction; multiplication; and division,
 * using those integers.*/
class Program
{
  static void Main()
  {
    // Prompt the user for two integers
    Console.Write("First positive integer: ");
    int numOne = Convert.ToInt32(Console.ReadLine());
    Console.Write("Second positive integer: ");
    int numTwo = Convert.ToInt32(Console.ReadLine());

    // Separate the results from the inputted integers
    Console.WriteLine();

    // Display the results
    Console.WriteLine
    (
      $"Sum: {numOne + numTwo:N0}\n" +
      $"Product: {numOne * numTwo:N0}\n" +
      $"Difference: {numOne - numTwo:N0}\n" +
      $"Quotient: {(float)numOne / numTwo:N}\n" +
      $"Remainder: {numOne % numTwo:N0}"
    );
  } // End Main
} // End Program