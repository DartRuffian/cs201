using System;

/**
 * @author William Grate
 * Class BlackJack simulates a simple game of two-card Blackjack. */
class BlackJack
{
  private static Random deck; // Generates random cards
  private const int MAX_WINS = 5;
  // Card Numbers
  private const int ACE = 11;
  private const int JACK = 12;
  private const int QUEEN = 13;
  private const int KING = 14;

  // You may declare other private CONSTANT fields here if they are needed
  // in two or more methods. (Variables are to be declared in the methods)

  /** Parameterless constructor ALREADY COMPLETED*/
  public BlackJack()
  {
    deck = new Random();
  }

  /** Run the BlackJack game */
  public void Run()
  {
    // Display the directions. (Call the appropriate method)
    IntroduceGame();
    // Deal cards while the player or house has not reached
    // the maximum number of wins. Remember to use the MAX_WINS
    // named constant instead of 5.
    int numWinsPlayer = 0;
    int numWinsHouse = 0;

    while (numWinsPlayer < MAX_WINS && numWinsHouse < MAX_WINS)
    {
      // Clear the window and announce a new game. ALREADY COMPLETED
      Console.Write("Press any key to deal cards . . .");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("=========================================");
      Console.WriteLine("New game...");
      Console.WriteLine("=========================================");

      // Call DealCards to "deal" the first card to the player and the
      // house. You will need to declare 2 descriptive variables to
      // send to DealCards. Do not initialize when declaring as these  
      // will be out parameters in the call to DealCards
      DealCards(out int playerCard1, out int houseCard1);

      // Call DealCards to "deal" the second card to the player and the
      // house. This is just like what was just done for the first card.
      DealCards(out int playerCard2, out int houseCard2);

      // Display the result for the player in the format: 
      //   Player: card1, card2 (score)
      //   Example --> Player: A, 2 (13)
      //  
      //   Requirement: 
      //      Player: is displayed here. Then call DisplayCards 
      //      which displays card1, card2 e.g. A, 2
      //      Then, call and store the returned result from GetScore 
      //      and display that score between two parentheses.
      //      Note: Unlike DisplayCards, there is no write statement
      //      in GetScore as the value is only returned. 
      DisplayCards(playerCard1, playerCard2);
      int totalPlayerScore = GetScore(playerCard1, playerCard2);
      Console.WriteLine($"({totalPlayerScore})");


      // Similar to the player, do display results for the house
      DisplayCards(houseCard1, houseCard2);
      int totalHouseScore = GetScore(houseCard1, houseCard2);
      Console.WriteLine($"({totalHouseScore})");

      // Display who won or if it was a tie. If not a tie, add 
      // one to the winner's win total (Nothing is added to win totals
      // for a tie.) You will need to have previously declared variables 
      // to hold the win totals.
      if (totalPlayerScore == totalHouseScore)
        Console.WriteLine("Tie!");
      else if (totalPlayerScore > totalHouseScore)
      {
        Console.WriteLine("Player Wins!");
        numWinsPlayer++;
      }
      else
      {
        Console.WriteLine("House Wins!");
        numWinsHouse++;
      }

      // Display the total wins so far for the house and player
      // in the form:
      // Total Player Wins: number of player wins
      // Total House Wins: number of house wins
      Console.WriteLine();
      Console.WriteLine($"Total Player Wins: {numWinsPlayer}\n" +
        $"Total House Wins: {numWinsHouse}");

    } // End while

    // Announce who reached MAX_WINS wins first
    if (numWinsPlayer == MAX_WINS)
      Console.WriteLine($"Player reaches {MAX_WINS} first!");
    else
      Console.WriteLine($"House reaches {MAX_WINS} first!");
  }

  /**
	* DealCards assigns a random integer between 2 and 14 inclusively
	* to the player card and the house card.
	* Numeric card representation:
	*   2 - 10: represents the numeric face value of the card
	*   11: represents an Ace
	*   12 - 14: represents Jack, Queen, and King respectively 
	* @param playerCard Will hold the generated number for the player
	* @param houseCard Will hold the generated number for the house 
	* Hint: The method does not return a value, so use out or ref
	* parameters for playerCard and houseCard. */
  public void DealCards(out int playerCard, out int houseCard)
  {
    playerCard = deck.Next(2, 15);
    houseCard = deck.Next(2, 15);
  } // end DealCards

  /**
	* DisplayCards displays the two cards for a given hand in the form
	*      card,<space>card<space>   (No new line)
	*  e.g    K, 8 
	* Card display:
	*   2 - 10: The number is displayed
	*   11: A is displayed
	*   12 - 14: J, Q, or K respectively is displayed
	* @param card1 Number representing the person's first card
	* @param card2 Number representing the person's second card 
	* @precondition Each card parameter contains a number in the
	*               range 2 - 14 */
  public void DisplayCards(int card1, int card2)
  {
    string strCard1 = "";
    string strCard2 = "";

    switch (card1)
    {
      case 11:
        strCard1 = "A";
        break;
      case 12:
        strCard1 = "J";
        break;
      case 13:
        strCard1 = "Q";
        break;
      case 14:
        strCard1 = "K";
        break;
      default:
        strCard1 = card1.ToString();
        break;
    }
    switch (card2)
    {
      case 11:
        strCard2 = "A";
        break;
      case 12:
        strCard2 = "J";
        break;
      case 13:
        strCard2 = "Q";
        break;
      case 14:
        strCard2 = "K";
        break;
      default:
        strCard2 = card2.ToString();
        break;
    }

    Console.Write($"{strCard1}, {strCard2} ");
  } // end DisplayCards;

  /**
	* GetScore computes the total score for a given hand by adding
	* the values of the two cards. To compute a card value
	*   2 - 11: The value of the card is the number
	*   12 - 14: The value of the card is 10
	*   Note: If a person has 2 Aces, the value of one of them is
	*         treated as a 1. (Total score would be 12)
	* @param card1 Number representing the person's first card
	* @param card2 Number representing the person's second card 
	* @precondition Each card parameter contains a number in the range
	*               2 - 14
	* @return The total score */
  public int GetScore(int card1, int card2)
  {
    // If a card number is greater than 12 (i..e a face card), reduce it to 10
    if (card1 >= JACK) card1 = 10;
    if (card2 >= JACK) card2 = 10;

    // If both cards are aces, one card counts as a 1
    if (card1 == ACE && card2 == ACE) card1 = 1;

    // Scores of both cards are finalized, return the sum
    return card1 + card2;
  } // end GetScore

  /** IntroduceGame introduces the game ALREADY COMPLETED */
  public void IntroduceGame()
  {
    Console.WriteLine(
        "**************************************************\n" +
        "Welcome to Two Card Black Jack!\n" +
        "The house and the player are each dealt two cards.\n" +
        "The value of each hand is computed and the winner\n" +
        "is announced. The game ends when either the player\n" +
        $"or the house wins {MAX_WINS} games.\n" +
        "**************************************************");
  } // end IntroduceGame
} // end class