using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string log, string separator)
    {
        string[] words = log.Split(separator);

        return words[1];
    }

    public static string SubstringBetween(this string log, string firstChar, string secondChar)
    {
        string output = "";
        int startPos = log.IndexOf(firstChar, 0);
        int endPos = log.IndexOf(secondChar, 0);
        int firstCharLength = firstChar.Length;

        if (startPos == -1)
        {
            startPos = 0;
            firstCharLength = 0;
        }

        if (endPos == -1)
        {
            endPos = log.Length;
        }

        for(int i = (startPos + firstCharLength); i < endPos; ++i)
        {
            output += log[i];
        }

        return output;
    }
    
    public static string Message(this string log)
    {
        string[] words = log.Split(": ");

        return words[1];
    }

    public static string LogLevel(this string log)
    {
        string[] words = log.Split(": ");
        string level = words[0];

        return level.SubstringBetween("[", "]");
    }
}