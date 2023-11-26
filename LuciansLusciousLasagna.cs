class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int actualMinutes)
    {
        return ExpectedMinutesInOven() - actualMinutes;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return 2 * layers;
    }

    public int ElapsedTimeInMinutes(int layers, int actualMinutes)
    {
        return PreparationTimeInMinutes(layers) + actualMinutes;
    }
}
