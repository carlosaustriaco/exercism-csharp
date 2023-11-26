using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0)
            return 0;
        else if ((speed >= 1) && (speed <= 4))
            return 1;
        else if ((speed >= 5) && (speed <= 8))
            return 0.9;
        else if (speed == 9)
            return 0.8;
        else 
            return 0.77;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        const int carsPerSpeed = 221;

        return speed * carsPerSpeed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double productionPerHour = ProductionRatePerHour(speed);

        return (int)(productionPerHour / 60);
    }
}
