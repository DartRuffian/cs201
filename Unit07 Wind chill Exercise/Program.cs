/**
 * @author William Grate
 * Class Program will compute a temperature with the windchill factored in.
 */
internal class Program
{
  static void Main()
  {
    // Get a valid temperature
    const int HIGH_TEMP = 50;
    int temp;
    do
    {
      Console.Write($"Enter a Fahrenheit temperature less than or equal " +
        $"to {HIGH_TEMP}: ");
      temp = int.Parse(Console.ReadLine());
    } while (temp > HIGH_TEMP);

    // Get a valid wind speed
    const int LOW_WIND = 3;
    int windSpeed;
    do
    {
      Console.Write($"Enter a wind speed in MPH > {LOW_WIND}");
      windSpeed = int.Parse(Console.ReadLine());
    } while (windSpeed < LOW_WIND);

    Console.WriteLine($"Windchill Temperature: " +
      $"{ComputeWindChill(temp, windSpeed):N1} degrees Fahrenheit.");
  } // end Main

  /**
   * ComputeWindChill computes the windchill temperature given a temperature
   * and wind speed.
   * @param temp The temperature in Fahrenheit
   * @param windSpeed The wind speed in mph
   * @precondition temp <= 50 and windSpeed > 3
   * @return The calculated wind chill temperature
   */
  static double ComputeWindChill(int temp, int windSpeed)
  {
    return 35.74f + 0.6215f * temp - 35.75f * Math.Pow(windSpeed, 0.16f) + 
      0.4275 * temp * Math.Pow(windSpeed, 0.16f);
  } // end ComputeWindChill
} // end Program