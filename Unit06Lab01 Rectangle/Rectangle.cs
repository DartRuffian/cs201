/**
 * @author William Grate
 */
public class Rectangle
{
  private int length;
  private int width;

  // Constructor
  public Rectangle(int length, int width)
  {
    Length = length;
    Width = width;
  }

  // Accessors and Mutators
  public int Length
  {
    get { return length; }
    set
    {
      if (value >= 0) length = value;
    }
  } // end property Length

  public int Width
  {
    get { return width; }
    set
    {
      if (value >= 0) width = value;
    }
  } // end property Width

} // end class
