using System;
/**
 * @author William Grate
 * Class Program recursively calculates exponential values. */
public class Program
{
  public static void Main()
  {
    int baseInt;
    int exponent;

    GetInput(out baseInt, out exponent);
    Console.WriteLine($"{baseInt}^{exponent} = " +
      $"{ComputePower(baseInt, exponent)}");
  } // end Main

  /**
	 * GetInput retrieves a numeric base and exponent from the user.
	 * @param baseInt Will contain the user-entered base integer
	 * @param exponent Will contain the user-entered exponent*/
  public static void GetInput(out int baseInt, out int exponent)
  {
    Console.Write("Enter the base: ");
    baseInt = int.Parse(Console.ReadLine());
    Console.Write("Enter the exponent: ");
    exponent = int.Parse(Console.ReadLine());
  }

  /**
	 * ComputePower calculates baseInt raised to the exponent power
	 * @precondition exponent > 0.
	 * @param baseInt The base integer of the power calculation.
	 * @param exponent The exponent to which the baseInt is raised. 
	 * @return The value of baseInt raised to the exponent power. */
  public static long ComputePower(int baseInt, int exponent)
  {
    if (exponent == 1) return baseInt;
    else
    {
      return baseInt * ComputePower(baseInt, exponent - 1);
    }
  }
}
