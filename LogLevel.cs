using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        string[] substrings = logLine.Split(':');
        return substrings[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        string[] substrings = logLine.Split(':');
        string errorCode = substrings[0];
        
        errorCode = errorCode.Substring(1, errorCode.Length - 2);
        return errorCode.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string error = LogLevel(logLine);

        return message + " (" + error + ')';
    }
}
