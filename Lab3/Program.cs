using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        double a = -5;
        double b = 6; // Границы интервала поиска корней
        double step = 0.0001; // Шаг для поиска изменения знака
        List<double> roots = FindAllRoots(a, b, step, Dihotomin);

        Console.WriteLine("Найденные корни:");
        foreach (var root in roots)
        {
            Console.WriteLine(root);
        }
    }

    // Функция
    static double Funcsian(double x)
    {
        return (0.2 * x) * (0.2 * x) * (0.2 * x) - Math.Cos(x);
    }

    // Метод дихотомии
    static double Dihotomin(double a, double b)
    {
        double c;
        while (Math.Abs(a - b) > 1e-6) // Точность 10^-6
        {
            c = (a + b) / 2;
            if (Funcsian(c) * Funcsian(a) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
        }
        return (a + b) / 2;
    }

    // Метод для поиска всех корней
    static List<double> FindAllRoots(double a, double b, double step, Func<double, double, double> method)
    {
        List<double> roots = new List<double>();

        double current = a;
        while (current < b)
        {
            double next = current + step;

            // Проверяем изменение знака на подынтервале
            if (Funcsian(current) * Funcsian(next) < 0)
            {
                double root = method(current, next);
                roots.Add(root);
            }

            current = next;
        }

        return roots;
    }
}