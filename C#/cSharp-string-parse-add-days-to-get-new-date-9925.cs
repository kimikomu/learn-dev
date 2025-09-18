using System;

public class Solution
{
    // FIRST ATTEMPT

    public static string AddDays(string date, int numberOfDays)
    {
        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        string[] dateSplit = date.Split("-");
        int year = int.Parse(dateSplit[0]);
        int month = int.Parse(dateSplit[1]);
        int day = int.Parse(dateSplit[2]);

        // get the remainding days left in the month given in the date
        int daysLeftInGivenMonth = month == 2 && IsLeapYear(year) ?
            daysInMonth[month] - day + 1 : daysInMonth[month] - day;    // adjust for leap year

        // get the remainding days left in the year given in the date
        int daysLeftInGivenYear = daysLeftInGivenMonth;
        for (int i = month + 1; i <= 12; i++)
        {
            daysLeftInGivenYear += daysInMonth[i];
            if (i == 2 && IsLeapYear(year))
            {
                daysLeftInGivenYear++;                                  // adjust for leap year
            }
        }
        numberOfDays -= daysLeftInGivenYear;

        // get the year count for all of the complete years following the first year
        int yearsAfterFirstYear = 0;

        while (numberOfDays >= 365)
        {
            yearsAfterFirstYear++;
            numberOfDays = IsLeapYear(year + yearsAfterFirstYear) ?     // adjust for leap year
                numberOfDays -= 366 : numberOfDays -= 365;
        }

        // return if the date ends at the completion of a year
        if (numberOfDays <= 0)
        {
            return string.Format($"{year + yearsAfterFirstYear}-12-31");
        }

        // if not, get the remainging days for the last partial year
        int newYear = year + yearsAfterFirstYear + 1;
        int newMonth = 1;

        while (numberOfDays >= 28)
        {
            numberOfDays -= daysInMonth[newMonth];
            if (newMonth == 2 && IsLeapYear(newYear))
            {
                numberOfDays--;                                         // adjust for leap year
            }

            newMonth++;
        }

        // if there are no days remaining, end on the last day of the new month
        int newDay = numberOfDays > 0 ? numberOfDays : daysInMonth[newMonth];

        return string.Format("{0:D4}-{1:D2}-{2:D2}", newYear, newMonth, newDay);
    }

    private static bool IsLeapYear(int year)
    {
        if (year % 4 != 0)
            return false;
        else if (year % 100 != 0)
            return true;
        else if (year % 400 != 0)
            return false;
        else
            return true;
    }


    // USING C# BUILT-IN FEATURES
    public static string AddDays(string date, int numberOfDays)
    {
        DateTime dt = DateTime.Parse(date);
        DateTime newDate = dt.AddDays(numberOfDays);

        string[] dateWithoutTime = newDate.ToString().Split();
        string[] dateArray = dateWithoutTime[0].Split("/");

        int year = int.Parse(dateArray[2]);
        int month = int.Parse(dateArray[0]);
        int day = int.Parse(dateArray[1]);

        return string.Format("{0:D4}-{1:D2}-{2:D2}", year, month, day);
    }


    // USING ONE LOOP
    public static string AddDays(string date, int numberOfDays)
    {
        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        string[] dateSplit = date.Split("-");
        int year = int.Parse(dateSplit[0]);
        int month = int.Parse(dateSplit[1]);
        int day = int.Parse(dateSplit[2]);

        daysInMonth[2] = IsLeapYear(year) ? 29 : 28;

        while (numberOfDays > 0)
        {
            day++;
            numberOfDays--;

            if (day > daysInMonth[month])
            {
                day = 1;
                month++;

                if (month > 12)
                {
                    month = 1;
                    year++;
                    daysInMonth[2] = IsLeapYear(year) ? 29 : 28;
                }
            }
        }

        return string.Format("{0:D4}-{1:D2}-{2:D2}", year, month, day);
    }


    // CONDENSING TO CHECKING MONTHS --- Not working yet.
    public static string AddDays(string date, int numberOfDays)
    {
        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        string[] dateSplit = date.Split("-");
        int year = int.Parse(dateSplit[0]);
        int month = int.Parse(dateSplit[1]);
        int day = int.Parse(dateSplit[2]);

        daysInMonth[2] = IsLeapYear(year) ? 29 : 28;
        Console.Write(month + ", ");
        while (numberOfDays > daysInMonth[month])
        {
            numberOfDays -= daysInMonth[month] - day;
            
            if (month >= 12)
            {
                year++;
                daysInMonth[2] = IsLeapYear(year) ? 29 : 28;
                month = 1;
            }
            else
            {
                month++;
            }
            Console.Write(month + ", ");
            day = 0;
        }
        
        day = numberOfDays > 0 ? numberOfDays : daysInMonth[month];
        return string.Format("{0:D4}-{1:D2}-{2:D2}", year, month, day);
    }  
}