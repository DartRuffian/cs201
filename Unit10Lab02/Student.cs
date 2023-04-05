using System;
/**
 * @author William Grate
 * Class Student represents a student with an id and test scores
 */
class Student
{
	// Declare a public property named Id that will hold a numeric id.
	// Use the string data type because ids may begin with 0
	public string Id;
	// Declare a private field named testScores that will hold an 
	// array of integers. Just declare but do not initialize here.
	private int[] testScores;
  // Completed. Random number generator used to generate test scores
  static Random scoreGenerator = new Random();

  /** 
	 * Constructor
	 * @param newId The student id
	 * @param numScores The number of test scores
	 * (The constructor consists of two statements. One assigns the
	 * incoming id to the id property. The second assigns a NEW integer
	 * array of numScores size to the testScores field. DO NOT again 
	 * redeclare testScores here because that was previously done in the
	 * field above.) */
  public Student(string newId, int numScores)
  {
		Id = newId;
		testScores = new int[numScores];
  }

  /** 
	 * Method CreateScores assigns random test scores in a given range.
	 * @param lowScore The lowest value of potential test scores
	 * @param highScore The highest value of potential test scores
	 * (Loop to assign a random integer in the range from lowScore 
	 * through highScore to each of the testScore slots. Utilize the 
	 * scoreGenerator object already created in the field above to 
	 * generate the random scores.) */
  public void CreateScores(int lowScore, int highScore)
  {
		for (int i = 0; i < testScores.Length; i++)
		{
			testScores[i] = scoreGenerator.Next(lowScore, highScore + 1);
    }
  }

  /** 
	 * Method getStudentData returns a string of the form
	 *    id: score1 score2 ... scoreN
	 * @return a string representation of the Student 
	 * (Begin the string with the students id and a colon. Then, 
	 * loop to append (+) each test score to the string with a 
	 * space separator. */
  public string GetStudentData()
  {
		return $"{Id}: {String.Join(" ", testScores)}";
  }

} // end Student
