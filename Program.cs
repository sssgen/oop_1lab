using System;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо відрізки для початку
        int N = 11; // Кількість відрізків
        LineSegmentManager manager = new LineSegmentManager(N);

        Console.WriteLine("Вiдрiзки за замовчуванням:");
        manager.DisplayLineSegments();

        // Додаємо нові відрізки
        int segmentsToAdd = 5; // Кількість нових відрізків
        manager.AddRandomLineSegments(segmentsToAdd);
        Console.WriteLine($"\nПiсля додавання {segmentsToAdd} нових вiдрiзкiв:");
        manager.DisplayLineSegments();

        // Видаляємо відрізок
        int segmentToRemove = 2; // Номер відрізку для видалення
        manager.RemoveLineSegment(segmentToRemove - 1);
        Console.WriteLine($"\nПiсля видалення {segmentToRemove} вiдрiзку:");
        manager.DisplayLineSegments();

        // Пошук відрізку за кутом
        double targetAngle = 45; // Шукаємо відрізки з кутом 45 градусів
        Console.WriteLine($"\nПошук вiдрiзкiв з кутом {targetAngle} градусiв:");
        manager.FindSegmentsByAngle(targetAngle); // Виведення відбуватиметься в цьому методі
    }
}
