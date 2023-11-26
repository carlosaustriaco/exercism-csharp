using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new [] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return this.birdsPerDay[this.birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        this.birdsPerDay[this.birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        bool daysWithoutBirds = false;

        foreach (int count in this.birdsPerDay)
        {
            if (count == 0)
            {
                daysWithoutBirds = true;
                break;
            }
        }

        return daysWithoutBirds;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        int i = 0;

        while ((i < numberOfDays) && (i < this.birdsPerDay.Length))
        {
            count += this.birdsPerDay[i];            
            i++;
        }

        return count;
    }

    public int BusyDays()
    {
        int busy = 0;

        foreach (int count in this.birdsPerDay)
        {
            if (count >= 5)
            {
                busy++;
            }
        }

        return busy;
    }
}
