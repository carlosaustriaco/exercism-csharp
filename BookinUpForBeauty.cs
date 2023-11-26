using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime date = DateTime.Parse(appointmentDateDescription);

        return date;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime currentDateTime = DateTime.Now;
        int result = DateTime.Compare(appointmentDate, currentDateTime);

        return (result < 0);
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        int appointmentHour = appointmentDate.Hour;
        int appointmentMinute = appointmentDate.Minute;

        return ((appointmentHour > 12) || ((appointmentHour == 12) && (appointmentMinute >= 0))) &&
               (appointmentHour < 18);
    }

    public static string Description(DateTime appointmentDate)
    {
        return "You have an appointment on " + appointmentDate.ToString() + ".";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(2023, 9, 15, 0, 0, 0, 0, 0);
    }
}
