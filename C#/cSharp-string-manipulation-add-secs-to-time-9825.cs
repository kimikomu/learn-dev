// You are given two input arguments: an array of strings timePoints and an integer addedSeconds.
// Each string in timePoints is in the HH:MM:SS format, representing a valid time from "00:00:00" to "23:59:59" inclusive.
// The integer addedSeconds represents a number of seconds, ranging from 1 to 86,400. Your task is to create a new function,
// AddSecondsToTimes, which takes these two arguments and returns a new array of strings. Each string in the returned array is the new time,
// calculated by adding the provided addedSeconds to the corresponding time in timePoints, formatted in HH:MM:SS.

// The array timePoints contains n strings, where n can be any integer from 1 to 100 inclusive.
// The time represented by each string in timePoints is guaranteed to be valid. The total time, after adding addedSeconds, can roll over to the next day.

// Example:
// For timePoints = ['10:00:00', '23:30:00'] and addedSeconds = 3600, the output should be ['11:00:00', '00:30:00'].

using System;

// input: 1. array of strings in HH:MM:SS format from midnight to 23:59:59. array length is from 1 to 100 inclusive.
//        2. int of number of seconds from 1 to 86,4000. seconds can roll over to next day.
// todo: add the number of seconds to each string in the array
// output: new array of strings with new times
public class Solution
{
    public static string[] AddSecondsToTimes(string[] timePoints, int addedSeconds)
    {
        int secondsInHour = 3600;
        int length = timePoints.Length;
        string[] newTimeStrings = new string[length];
        
        for (int i = 0; i < length; i++)
        {
            // parse the string input into ints
            string[] timeString = timePoints[i].Split(":");
            int hours = int.Parse(timeString[0]);     // hours
            int mins = int.Parse(timeString[1]);      // mins
            int secs = int.Parse(timeString[2]);      // secs
        
            // calculate the number of seconds that have elapsed since midnight
            int secsSinceMidnight = (hours * secondsInHour) + (mins * 60) + secs;
            
            // add the addedSeconds int to the calculation, ensure overlap loops past midnight
            int totalSecs = (secsSinceMidnight + addedSeconds) % (24 * secondsInHour);
            
            // convert the number of seconds into hours, mins, and secs
            int newHours = totalSecs / secondsInHour;
            int remainder = totalSecs % secondsInHour;
            int newMins = remainder / 60;
            int newSecs = remainder % 60;
            
            // format into time and add to array
            newTimeStrings[i] = string.Format("{0:D2}:{1:D2}:{2:D2}", newHours, newMins, newSecs);
        }
        return newTimeStrings;
    }
}
