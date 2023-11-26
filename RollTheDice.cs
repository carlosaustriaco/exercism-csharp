using System;

public class Player
{
    public int RollDie()
    {
        Random rdm = new Random();

        return rdm.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        Random rdm = new Random();

        return rdm.NextDouble() * 100;
    }
}
