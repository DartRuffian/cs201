/**
 * @author William Grate
 * Class Program calculate the surface area or volume of a sphere using
 * parameters from the user.
 */
internal class Program
{
  static void Main()
  {
    // Prompt user for the radius of the sphere
    Console.Write("Enter the radius (feet): ");
    float radius = float.Parse(Console.ReadLine());

    if (radius <= 0)
      {
        // Radius is invalid if r <= 0
        Console.WriteLine("I'm sorry, an invalid radius was entered.");
        return; // End early if invalid radius
      };

    // Prompt the user to calculate SA or V
    Console.Write("Enter S (Surface Area) or V (Volume): ");
    string choice = (Console.ReadLine()).ToLower();

    Console.WriteLine(); // Spacer

    if (choice == "s")
    {
      // Surface Area
      Console.WriteLine("Surface Area: " +
        $"{4 * Math.PI * (Math.Pow(radius, 2)):N3} square feet");
    }
    else if (choice == "v")
    {
      // Volume
      Console.WriteLine("Volume: " +
        $"{(4/3.0) * Math.PI * (Math.Pow(radius, 3)):N3} cubic feet");
    }
    else
    {
      // Invalid Choice
      Console.WriteLine("I'm sorry, I didn't understand your choice.");
    };
  }
}