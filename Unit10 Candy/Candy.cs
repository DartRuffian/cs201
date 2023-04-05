internal class Candy
{
  public string Name { get; set; }
  private decimal price;

  public decimal Price
  {
    get { return price; }
    set
    {
      if (value >= 0) price = value;
    }
  } // end Price

  public Candy(string newName, decimal newPrice)
  {
    Name = newName;
    Price = newPrice;
  }

  public Candy()
  {
    Name = "";
    Price = 0;
  }

  public override string ToString()
  {
    return $"{Name}, {Price:C}";
  } //end ToString
} // end Candy