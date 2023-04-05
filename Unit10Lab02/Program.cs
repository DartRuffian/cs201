using System;

/**
 * @author William Grate
 * Class Program tests the Student class
 */
class Program
{
  static void Main()
  {
    const int LOW_SCORE = 60;
    const int HIGH_SCORE = 100;
    const int TOTAL_SCORES = 5;

    // Add one statement to create a new Student object named 
    // testStudent with an id of "0012345" and the ability to hold
    // TOTAL_SCORES test scores
    Student testStudent = new Student("0012345", TOTAL_SCORES);

    // Add one statement to create the test scores with the LOW_SCORE
    // and HIGH_SCORE range. You will need to call the CreateScores 
    // method for the test student object.
    testStudent.CreateScores(LOW_SCORE, HIGH_SCORE);

    // Add one statement to display the string representation of the
    // student just created. Within a WriteLine, embed a call to 
    // GetStudentData for the testStudent object.
    Console.WriteLine(testStudent.GetStudentData());
  } // end Main

} // end class