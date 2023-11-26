using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phoneNumberParts = phoneNumber.Split('-');
        string part1 = phoneNumberParts[0];
        string part2 = phoneNumberParts[1];
        string part3 = phoneNumberParts[2];

        return (part1 == "212", part2 == "555", part3);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
