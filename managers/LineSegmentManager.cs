using System;

public class LineSegmentManager
{
    private LineSegment[] segments;

    public int SegmentCount => segments?.Length ?? 0;

    public LineSegmentManager(int initialCount)
    {
        segments = new LineSegment[initialCount];
        AddRandomLineSegments(initialCount);
    }

    public void AddRandomLineSegments(int count)
    {
        Random random = new Random();
        LineSegment[] newSegments = new LineSegment[SegmentCount + count];

        if (segments != null && segments.Length > 0)
        {
            Array.Copy(segments, newSegments, segments.Length);
        }

        for (int i = 0; i < count; i++)
        {
            double x1 = random.Next(-10, 10);
            double y1 = random.Next(-10, 10);
            double x2 = random.Next(-10, 10);
            double y2 = random.Next(-10, 10);
            newSegments[segments.Length + i] = new LineSegment(x1, y1, x2, y2);
        }

        segments = newSegments;
    }

    public void RemoveLineSegment(int segmentPosition)
    {
        if (segmentPosition < 0 || segmentPosition >= SegmentCount)
            throw new ArgumentOutOfRangeException(nameof(segmentPosition), "Такого елементу в масивi не iснує.");

        LineSegment[] newSegments = new LineSegment[SegmentCount - 1];

        for (int i = 0, j = 0; i < SegmentCount; i++)
        {
            if (i != segmentPosition)
            {
                newSegments[j] = segments[i];
                j++;
            }
        }

        segments = newSegments;
    }

    public void DisplayLineSegments()
    {
        if (segments == null || segments.Length == 0)
        {
            Console.WriteLine("Немає вiдрiзкiв для вiдображення.");
            return;
        }

        for (int i = 0; i < segments.Length; i++)
        {
            segments[i]?.PrintInfo();
        }
    }

    public LineSegment[] FindSegmentsByAngle(double targetAngle)
    {
        if (segments == null || segments.Length == 0)
        {
            Console.WriteLine("Немає вiдрiзкiв для пошуку.");
            return Array.Empty<LineSegment>();
        }

        List<LineSegment> matchingSegments = new List<LineSegment>();

        foreach (LineSegment segment in segments)
        {
            // Перевірка на null перед тим, як використовувати сегмент
            if (segment != null && Math.Abs(segment.GetAngleWithOY() - targetAngle) < 0.01) // Допустима похибка
            {
                matchingSegments.Add(segment);
            }
        }

        if (matchingSegments.Count > 0)
        {
            Console.WriteLine($"Знайдено {matchingSegments.Count} вiдрiзкiв з кутом {targetAngle} градусiв:");
            foreach (var segment in matchingSegments)
            {
                segment.PrintInfo();
            }
        }
        else
        {
            Console.WriteLine($"Не знайдено вiдрiзкiв з кутом {targetAngle} градусiв.");
        }

        return matchingSegments.ToArray();
    }
}
