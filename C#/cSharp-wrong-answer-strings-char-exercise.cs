// There's a multiple-choice test with N questions, numbered from 1 to N. Each question has 2 answer options, labelled A and B.
// You know that the correct answer for the ith question is the ith character in the string C, which is either "A" or "B", but
// you want to get a score of 0 on this test by answering every question incorrectly.

// our task is to implement the function getWrongAnswers(N, C) which returns a string with N characters, the ith of which is the
// answer you should give for the question i in order to get it wrong (either "A" or "B").

// Reminder that strings are doubled quotes ("a") in C#, and chars are single quotes ('a').
using System.Text;

class Solution {
  
  public string getWrongAnswers(int N, string C) {
    
    // use System.Text.StringBuilder for easy string manipulation.
    StringBuilder sb = new StringBuilder(C);
    
    for (int i = 0; i < N; i++)
    {
      if (sb[i] == 'A')  // StringBuilder creates an array of characters from the string, so you must compare 'A' and NOT "A".
      {
        sb[i] = 'B';
      }
      else
      {
        sb[i] = 'A';
      }
    }
    
    return sb.ToString();
  }
}
