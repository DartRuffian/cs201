using System; // May already be implicitly included in your VS version
using System.IO; // May already be implicitly included in your VS version
/**
 * Class Program finds the date of the highest price as well
 * as the average price for a simple file of mutual fund data.
 * A summary file is created with this data.
 * @author William Grate */
public class Program
{
  public static void Main() // MAIN MAY NOT BE CHANGED
  {
    string highDate = "";
    decimal highPrice = 0;
    decimal avgPrice = 0;

    ReadStockData(ref highDate, ref highPrice, ref avgPrice);
    WriteStockSummary(highDate, highPrice, avgPrice);
    Console.WriteLine("Data processing complete.");
  } // end Main

  /**
	 * ReadStockData reads stock prices and dates from a file and determines
	 * the highest closing price, the date of the highest closing price, and
	 * the average closing price.
	 * @precondition The input file is named PriceHistory.txt and is contained
	 * in the source code folder for this project. The file contains at least
	 * one record.
	 * @param highDate Will contain the date of the highest closing price.
	 * @param highPrice Will contain the highest closing price.
	 * @param avgPrice Will contain the average closing price. */
	public static void ReadStockData(ref string highDate, ref decimal highPrice, ref decimal avgPrice)
	{
		// Try to open the PriceHistory.txt file
		StreamReader inFile = null;
		try
		{
			string filePath = @"..\..\..\PriceHistory.txt";
			inFile = new StreamReader(new FileStream(filePath, FileMode.Open));
		}
		catch (Exception exc)
		{
			Console.WriteLine(exc.Message);
			Environment.Exit(1);
		}
		// File exists and was opened successfully

		decimal sumPrices = 0;
		int recordCount = 0;

		string record;
		while ((record = inFile.ReadLine()) != null)
		{
			string[] values = record.Split(',');
			// date, price
			string date = values[0];
			decimal price = decimal.Parse(values[1]);

			if (price > highPrice )
			{
				highDate = date;
				highPrice = price;
      }
			sumPrices += price;
			recordCount++;
		}
		avgPrice = sumPrices / (decimal)recordCount;
    inFile.Close();
  } // end ReadStockData

  /**
	 * WriteStockSummary writes a file named PriceSummary.txt to the
	 * project's source file folder. The format is:
	 * highDate highPrice
	 * avgPrice
	 * Each price will ensure a $, commas if needed, and 2 digits of 
	 * precision.
	 * @param highDate Contains the date of the highest closing price.
	 * @param highPrice Contains the highest closing price.
	 * @param avgPrice Contains the average closing price. */
	public static void WriteStockSummary(string highDate, decimal highPrice, decimal avgPrice)
	{
    StreamWriter outFile = null;
    try
    {
      string filePath = @"..\..\..\PriceSummary.txt";
			outFile = new StreamWriter(new FileStream(filePath, FileMode.Create));
    }
    catch (Exception exc)
    {
      Console.WriteLine(exc.Message);
      Environment.Exit(2);
    }
		// File created and was opened successfully
		outFile.Write($"{highDate},{highPrice:C}\n{avgPrice:C}");
    outFile.Close();
  } // end WriteStockSummary

} // end MainClass
