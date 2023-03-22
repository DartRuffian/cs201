/**
 * @author William Grate
 * Class Program simulates a simple login system, giving the user three chances
 * to enter the correct username and password.*/
internal class Program
{
  static void Main()
  {
    // Constants
    const string USERNAME = "jccc";
    const string PASSWORD = "cavs";
    const int MAX_LOGIN_ATTEMPTS = 3;

    // Get the user's login info
    (string inputUsername, string inputPassword) = GetLoginInfo();

    int numLoginAttempts = 1;

    // If login info is incorrect, try again an MAX_LOGIN_ATTEMPTS times
    while ((inputUsername.ToLower() != USERNAME || inputPassword != PASSWORD)
      && numLoginAttempts < MAX_LOGIN_ATTEMPTS)
    {
      Console.WriteLine("Login incorrect. Please re-enter your username and " +
                        "password.");
      (inputUsername, inputPassword) = GetLoginInfo();
      numLoginAttempts++;
    };

    // Display appropriate login message
    if (inputUsername == USERNAME && inputPassword == PASSWORD)
    {
      Console.WriteLine("Logging in...");
    }
    else
    {
      Console.WriteLine("Login disabled. Please contact your administrator.");
    }
  }

  // I didn't want to copy/paste so I just put the login messages into its own
  // method.
  static (string, string) GetLoginInfo()
  {
    // Prompt the user for the username
    Console.Write("Username: ");
    string inputUsername = Console.ReadLine().ToLower();

    // Prompt the username for the password
    Console.Write("Password: ");
    string inputPassword = Console.ReadLine();

    return (inputUsername, inputPassword);
  }
}