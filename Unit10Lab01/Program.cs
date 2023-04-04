/**
 * Class Program finds the lowest integer in an array.
 * @author William Grate
 */
internal class Program
{
  static void Main()
  {
    // Number of random numbers to generate
    const int MAX_LEN = 20;
    int[] numbers = new int[MAX_LEN];

    // Range of random numbers
    Random random = new Random();
    const int MAX_RAND_NUM = 50;
    const int MIN_RAND_NUM = -50;

    for (int i = 0; i < MAX_LEN; i++)
    {
      // Max is MAX_RAND_NUM + 1 because Next returns value less than it
      numbers[i] = random.Next(MIN_RAND_NUM, MAX_RAND_NUM + 1);
    }

    DisplayData(numbers);
    Console.WriteLine($"The lowest array value is {FindLowest(numbers)}.");
  } // end Main

  static void DisplayData(int[] numbers)
  {
    // Display all elements in the list, then "end" the line
    foreach (int num in numbers) { Console.Write($"{num} "); }
    Console.WriteLine();
  } // end DisplayData

  static int FindLowest(int[] numbers)
  {
    // Set "default" max value to the first index
    int max = numbers[0];
    // Loop over all elements, compare each element to the current highest
    // value
    foreach (int num in numbers)
    {
      if (num > max) max = num;
    }
    return max;
  } // end FindLowest
}