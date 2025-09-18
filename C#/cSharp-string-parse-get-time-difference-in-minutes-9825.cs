// You are given a time period formatted as a string in the HH:MM:SS - HH:MM:SS format. HH:MM:SS represents the time
// in hours, minutes, and seconds form, and the hyphen (-) separates the start time from the end time of the period.
// Your task is to calculate how many minutes pass from the start time until the end time.

// Here are some guidelines:
// The input times are always valid time strings in the HH:MM:SS format, with HH ranging from 00 to 23, and MM and SS from 00 to 59.
// The output should be an integer, representing the total length of the time period in minutes.
// The start time of the period will always be earlier than the end time, so periods that cross over midnight (like 23:00:00 - 01:00:00) are not considered.
// We are interested in the number of times the time passes some HH:MM:00 after the start time until the end time.
// Any remaining seconds should be disregarded; for instance, a period of "12:15:00 - 12:16:59" represents 1 minute, not 2,
// and a period of "12:14:59 - 12:15:00" also represents 1 minute.

// Example: TimePeriodLength("12:15:30 - 14:00:00");  // should return 105



// input: string of a period of time formatted as HH:MM:SS - HH:MM:SS. HH: 00-23, MM & SS: 00-59
// todo: get the minutes after the start time until the end time as an int. secs are not considered
// output: minutes between start time and end time

public class Solution
{
    public static int TimePeriodLength(string timePeriod)
    {
        // get the start and end times
        string[] timePeriods = timePeriod.Split("-");
        string[] startTime = timePeriods[0].Split(":");
        string[] endTime = timePeriods[1].Split(":");

        // get the start and end minutes
        int startHour = int.Parse(startTime[0]);
        int startMin = int.Parse(startTime[1]);

        int endHour = int.Parse(endTime[0]);
        int endMin = int.Parse(endTime[1]);

        int totalStartMins = (startHour * 60) + startMin;
        int totalEndMins = (endHour * 60) + endMin;

        // get the difference
        return totalEndMins - totalStartMins;
    }
}
