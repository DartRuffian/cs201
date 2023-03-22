
using System.Drawing;
using System.Security.Claims;
/**
 * @author William Grate
 * Class Program tests the Rectangle class.*/
class Program
{
  public static void Main()
  {
    // **ADD CODE ** 
    // Create a new Rectangle object named aRectangle
    // with a length of 3 and a width of 4. You are required
    // to call the constructor with the values of 3 and 4 and are
    // permitted to enter in the literal values rather than create
    // named constants. (One statement total)
    Rectangle aRectangle = new Rectangle(3, 4);


    // Display the rectangle dimensions 
    Console.WriteLine($"Length: {aRectangle.Length}, " +
        $"Width: {aRectangle.Width}");

    // Test that negative values are ignored
    aRectangle.Length = -2;
    aRectangle.Width = -4;
    Console.WriteLine($"Length: {aRectangle.Length}, " +
        $"Width: {aRectangle.Width}");

    // **ADD CODE ** 
    // Create a new Rectangle object named badRectangle
    // with a length of -3 and a width of -4. You are required
    // to call the constructor with the values of -3 and -4 and are
    // permitted to enter in the literal values rather than create
    // named constants. This will test if negative values are ignored.
    // (One statement total)
    Rectangle badRectangle = new Rectangle(-3, -4);

    // Display the rectangle dimensions 
    Console.WriteLine($"\nLength: {badRectangle.Length}, " +
      $"Width: {badRectangle.Width}");

    // Test that valid values may be set 
    aRectangle.Length = 2;
    aRectangle.Width = 4;
    Console.WriteLine($"Length: {aRectangle.Length}, " +
        $"Width: {aRectangle.Width}");

  } // end Main
} // end class
