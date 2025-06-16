using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string activityType = GetType().Name;
        return $"{_date.ToString("dd MMM yyyy")} {activityType} ({_minutes} min): Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm) : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        if (_minutes == 0) return 0;
        return (_distanceKm / _minutes) * 60;
    }

    public override double GetPace()
    {
        if (_distanceKm == 0) return 0;
        return _minutes / _distanceKm;
    }
}

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph) : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph * _minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        if (_speedKph == 0) return 0;
        return 60 / _speedKph;
    }
}

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersInKilometer = 1000;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (double)_laps * LapLengthMeters / MetersInKilometer;
    }

    public override double GetSpeed()
    {
        if (_minutes == 0) return 0;
        return (GetDistance() / _minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0;
        return _minutes / distance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2023, 11, 3), 30, 4.8));
        activities.Add(new Cycling(new DateTime(2023, 11, 4), 45, 25.0));
        activities.Add(new Swimming(new DateTime(2023, 11, 5), 20, 40));
        activities.Add(new Running(new DateTime(2023, 11, 6), 60, 10.0));
        activities.Add(new Cycling(new DateTime(2023, 11, 7), 30, 18.5));
        activities.Add(new Swimming(new DateTime(2023, 11, 8), 15, 25));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
