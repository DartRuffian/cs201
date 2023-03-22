/**
 * @author William Grate
 * Class Program displays a multiplication table with queried widths and
   lengths. Inputs include error catching*/
internal class Program
{
  static void Main()
  {
    // Maximum number of rows/columns (inclusive)
    const int MAX_ROWS_COLS = 10;

    // User inputted row/column numbers ; defined here but not assigned value.
    int num_rows;
    int num_cols;
    do
    {
      // Prompt user for number of rows/columns
      Console.Write($"Enter # of rows (1 <= # <= {MAX_ROWS_COLS:D}): ");
      num_rows = int.Parse(Console.ReadLine());
      Console.Write($"Enter # of columns (1 <= # <= {MAX_ROWS_COLS:D}): ");
      num_cols = int.Parse(Console.ReadLine());

      Console.WriteLine(); // Spacer
    } while (!(CheckRowColValue(MAX_ROWS_COLS, num_rows) && 
               CheckRowColValue(MAX_ROWS_COLS, num_cols)));

    // User has entered a value row/column pair
    // Outer loop for the rows
    for (int x = 1; x <= num_rows; ++x)
    {
      for (int y = 1; y <= num_rows; ++y)
      {
        Console.Write($"{x*y, -4}");
      }
      Console.WriteLine();
    }
  }

  static bool CheckRowColValue(int max, int num)
  {
    // Returns whether a given integer is greater than or equal to 1 and less
    // than or equal to 10
    // Exists to save space for the comparison in the do-while
    return 1 <= num && num <= max;
  }
}