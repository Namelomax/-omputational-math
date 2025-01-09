using System;

class Program
{
    static void Main()
    {
        double a = 1.0; // Начальное значение x
        double b = 2.0; // Конечное значение x
        double h = 0.1; // Шаг
        double y0 = 1.5; // Начальное условие y(x0)

        // Преобразуем уравнение в стандартный вид: y' = f(x, y)
        Func<double, double, double> f = (x, y) => (x/(y-x*x));

        // Решение ОДУ методом Рунге-Кутты 4-го порядка
        RungeKutta(f, a, b, h, y0);
    }

    static void RungeKutta(Func<double, double, double> f, double a, double b, double h, double y0)
    {
        int n = (int)((b - a) / h); // Количество шагов
        double[] x = new double[n + 1]; // Массив для значений x
        double[] y = new double[n + 1]; // Массив для значений y

        x[0] = a;
        y[0] = y0;

        for (int i = 0; i < n; i++)
        {
            double k1 = h * f(x[i], y[i]);
            double k2 = h * f(x[i] + h / 2, y[i] + k1 / 2);
            double k3 = h * f(x[i] + h / 2, y[i] + k2 / 2);
            double k4 = h * f(x[i] + h, y[i] + k3);

            x[i + 1] = x[i] + h;
            y[i + 1] = y[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;

            Console.WriteLine($"x: {x[i + 1]:F2}, y: {y[i + 1]:F4}");
        }
    }
}
