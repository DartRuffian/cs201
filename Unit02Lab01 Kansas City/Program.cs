/**
 * @author William Grate
 * Class Program displays the initials for Kansas City and also displays five
 * of its suburbs. */
class Program
{
  static void Main()
  {
    // Display Kansas City's initials
    // Combined into a single WriteLine
    Console.WriteLine
    (
      "*     *     *******\n" +
      "*   *      *\n" +
      "* *        *\n" +
      "*          *\n" +
      "* *        *\n" +
      "*   *      *\n" +
      "*     *     *******"
    );

    // Separate the initials from the suburbs
    Console.Write("\n");

    // List the suburbs and what state they are in
    Console.Write
    (
      "Suburb\t\t\tState\n" +
      "Overland Park\t\tKansas\n" +
      "Olathe\t\t\tKansas\n" +
      "Roeland Park\t\tKansas\n" +
      "Lee's Summit\t\tMissouri\n" +
      "Belton\t\t\tMissouri\n"
    );
  } // End Main
} // End Program