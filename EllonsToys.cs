using System;

class RemoteControlCar
{
    private int _distance = 0;
    private int _battery = 100;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return "Driven " + _distance.ToString() + " meters";
    }

    public string BatteryDisplay()
    {
        if (_battery > 0)
        {
            return "Battery at " + _battery.ToString() + "%";
        }
        else
        {
            return "Battery empty";
        }
    }

    public void Drive()
    {
        if (_battery > 0)
        {
            _distance += 20;
            _battery -= 1;            
        }
    }
}
