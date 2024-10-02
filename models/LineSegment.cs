using System;

public class LineSegment
{
    private double x1, y1, x2, y2;

    public LineSegment(double x1, double y1, double x2, double y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public double GetX1() => x1;
    public double GetY1() => y1;
    public double GetX2() => x2;
    public double GetY2() => y2;

    public double GetLength()
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public double GetAngleWithOY()
    {
        double dy = y2 - y1;
        double dx = x2 - x1;
        return Math.Atan2(dx, dy) * (180 / Math.PI); // Кут в градусах
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Початок: ({x1}, {y1}), Кiнець: ({x2}, {y2}), Довжина: {GetLength()}");
    }
}
