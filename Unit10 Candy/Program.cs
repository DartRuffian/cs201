/**
 * @author William Grate
 * Class Program is a tester class for Class Candy
 */
internal class Program
{
  static void Main(string[] args)
  {
    // Crate a list with a max of MAX_LEN elements
    const int MAX_LEN = 3;
    Candy[] bag = new Candy[MAX_LEN];

    FillBag(bag);
    ShowBagContents(bag);
  } // end Main

  public static void FillBag(Candy[] bag)
  {
    bag[0] = new Candy("Snickers", 1);
    bag[1] = new Candy("Reece's", 1.25m);
    bag[2] = new Candy("Rollo's", 0.75m);
  } // end FillBag

  public static void ShowBagContents(Candy[] bag)
  {
    foreach (Candy candy in bag) { Console.WriteLine(candy); }
  }
} // end Program