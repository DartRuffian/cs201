using System;
using System.Data.Common;
using System.IO;
using System.Security.Cryptography;
/**
* Class Program processes baseball player last names and hits
* from a comma delimited data file.
* @author William Grate */
class Program
{
  static void Main()
  {
    const int MAX_PLAYERS = 100;
    // Declare an array named lastNames that will hold up to
    // MAX_PLAYERS names
    string[] lastNames = new string[MAX_PLAYERS];
    // Declare an array named hits that will hold up to
    // MAX_PLAYERS hits (integers)
    int[] hits = new int[MAX_PLAYERS];
    int numPlayers = GetPlayerStats("PlayerStats.txt", lastNames, hits);
    // Display the total hits
    Console.WriteLine($"Total Hits: {GetTotalHits(hits, numPlayers):N0}");
    // Attempt to insert a new player
    Console.Write("Last name of new player? ");
    string playerLastName = Console.ReadLine();
    Console.Write($"Number of hits for {playerLastName}? ");
    int numHits = int.Parse(Console.ReadLine());
    int insertionIndex = FindPlayer(lastNames, playerLastName, numPlayers);
    if (insertionIndex >= 0)
      Console.WriteLine($"{playerLastName} already exists. ");
    else
    {
      // At this point we know that insertionIndex is negative.
      // Thus, look at the notes to use one line of code to transform
      // insertionIndex into a value where the insertion is to take place.
      //insertionIndex;
      // Then, write one loop that shifts values to the right to
      // make room. You will need to shift the data in both
      // the lastNames and the hits array inside the loop.
      // After the loop insert the player last name into the lastNames
      // array at the insertionIndex. Do the same for the hits
      
      for (int i = 1; i < numPlayers; i++)
      {
        string nameToMove = lastNames[i]; // Item to move into place
        int hitToMove = hits[i];
        int ii = i - 1; // Start just to the left

        // Shift items to the right until the beginning of the array has been
        // reached or a smaller item is found
        while ((ii >= 0) && (nameToMove != lastNames[ii]))
        {
          lastNames[ii + 1] = lastNames[ii];
          hits[ii + 1] = hits[ii];
          ii--;
        } // end while

        // Place item into correct location
        lastNames[ii + 1] = nameToMove;
        hits[ii + 1] = hitToMove;
      }
      lastNames[numPlayers] = playerLastName;
      hits[numPlayers] = numHits;
      numPlayers++;
    } // end else
    Console.WriteLine("Players, Hits (Sorted by last names)");
    for (int i = 0; i < numPlayers; ++i)
      Console.WriteLine($"{lastNames[i]}, {hits[i]}");
    // Sort by hits
    SortByHits(lastNames, hits, numPlayers);
    Console.WriteLine("\nPlayers, Hits (Sorted by hits)");
    for (int i = 0; i < numPlayers; ++i)
      Console.WriteLine($"{lastNames[i]}, {hits[i]}");
  } // end Main
  /**
  * GetPlayerStats reads player last names, at bats, and hits
  * from a given file and stores the data in a parallel manner into
  * the given arrays.
  * @param fileName The name of the file containing the statistics
  * @param lastNames An array that will hold the player last names
  * @param hits An array that will hold the player weights
  * @precondition The arrays contain enough elements to hold the number
  * of players read.
  * @return The number of players read from the file. */
  static int GetPlayerStats(string fileName, String[] lastNames,
  int[] hits)
  {
    // Open the input file (COMPLETED)
    StreamReader inFile = null;
    try
    {
      inFile = new StreamReader(
      new FileStream("..\\..\\..\\" + fileName, FileMode.Open));
    }
    catch (Exception exc)
    {
      Console.WriteLine("File open error: " + exc.Message);
      Environment.Exit(1);
    }
    // Skip the header (COMPLETED)
    inFile.ReadLine();
    // Write code to read in the players last names and hits into
    // the lastNames and hits arrays. This is similar to the lab with
    // stock prices. You will need to use split like the example with
    // comma delimiters in the notes, except now split will return an
    // array of data of size 5 instead of 2. You will need the data
    // at index 0 (last names) and the data at index 3 (hits)
    // Close the file when finished. Also, keep track of how many
    // players are read and return that value
    int numPlayers = 0;
    string record;

    while ((record = inFile.ReadLine()) != null)
    {
      string[] values = record.Split(',');
      // name and number of hits
      lastNames[numPlayers] = values[0];
      hits[numPlayers] = int.Parse(values[3]);
      numPlayers++;
    }
    inFile.Close();
    return numPlayers; // Replace 0 with the variable for the number of players read
  } // end method
  /**
  * GetTotalHits totals up all the hits for the players
  * @param hits An array of player hits
  * @param numPlayers The number of players
  * @return The total hits */
  static int GetTotalHits(int[] hits, int numPlayers)
  {
    // 0 is used as a placeholder value for empty indexes, so this is as simple
    // as returning the sum of the list.
    return hits.Sum(); // Replace 0 with the variable for the total hits
  } // end method
  /**
  * FindPlayer searches for the index of lastName in lastNames
  * @param lastNames The last names of the players
  * @param lastName The last name for which to search
  * @param numPlayers The number of last names in the array
  * @precondition The lastNames array is in ascending alphabetic order
  * @return the index of the found last name or a negative index
  * indicating where the name can be inserted. */
  static int FindPlayer(string[] lastNames, string lastName, int numPlayers)
  {
    int low = 0;
    int high = numPlayers - 1;

    while (high >= low)
    {
      int mid = (low + high) / 2;

      if (String.Compare(lastName, lastNames[mid], true) > 0)
        low = mid + 1;
      else if (String.Compare(lastName, lastNames[mid], true) < 0)
        high = mid - 1;
      else
      {
        Console.WriteLine(mid);
        return mid;
      }
    }
    Console.WriteLine(-low - 1);
    return -low - 1;
  } // end method
  /**
  * SortByHits will sort data in the arrays according to the player hits
  * @param lastNames An array of player last names
  * @param hits An array of player hits
  * @param numPlayers The number of players */
  static void SortByHits(string[] lastNames,
  int[] hits, int numPlayers)
  {
    for (int i = 0; i < numPlayers - 1; i++)
    {
      // Find the index of the smallest remaining item
      int indexSmallest = i;
      for (int ii = i + 1; ii < numPlayers; ii++)
      {
        if (hits[ii] < hits[indexSmallest])
          indexSmallest = ii;
      } // end for ii

      // Swap data if a smaller item was found
      if (indexSmallest != i)
      {
        int tmp = hits[i];
        hits[i] = hits[indexSmallest];
        hits[indexSmallest] = tmp;

        string tmpName = lastNames[i];
        lastNames[i] = lastNames[indexSmallest];
        lastNames[indexSmallest] = tmpName;
      }
    } // end for i
  } // end method
} //end class