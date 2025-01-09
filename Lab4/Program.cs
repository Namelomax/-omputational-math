internal class Program
{
    static void Main(string[] args)
    {
        double e = 1e-6;
        double a = 0;
        double b = 2; //a и b подбирайте сами, смотрите где на графике где ваш экстремум

        GoldSector(0, 2, e);
        Parabola(0, 2, e, 1); //где 1 тоже подбирайте число
    }

    static double f(double x)
    {
        return –(ТУТА ВАША ФУНКЦИЯ); //в скобках ваша функция и перед скобкой минус
    }

    static void GoldSector(double a, double b, double e)
    {
        double t = 0.5 * (1 + Math.Sqrt(5));
        double x1, x2, y1, y2, x;

        x1 = a + (b - a) / (t * t);
        y1 = f(x1);
        x2 = a + (b - a) / t;
        y2 = f(x2);

        while ((b - a) / t > 2 * e)
        {
            if (y1 < y2)
            {
                b = x2;
                x2 = x1;
                y2 = y1;
                x1 = a + b - x2;
                y1 = f(x1);
            }
            else
            {
                a = x1;
                x1 = x2;
                y1 = y2;
                x2 = a + b - x1;
                y2 = f(x2);
            }
        }
        x = (y1 < y2) ? (a + x2) / 2 : (x1 + b) / 2;
        y1 = f(x);
        Console.WriteLine($"Метод Золотого Сечения: x={x:F5} y={y1:F5}");
    }

    static void Parabola(double a, double b, double e, double c)
    {
        double s, t, yt;
        double ya = f(a);
        double yb = f(b);
        double yc = f(c);
        while (b - a > 2 * e)
        {
            s = c + 0.5 * ((b - c) * (b - c) * (ya - yc)
                - (c - a) * (c - a) * (yb - yc)) / ((b - c)
                * (ya - yc) + (c - a) * (yb - yc));
            if (s == c)
            {
                t = (a + c) / 2;
            }
            else { t = s; }
            yt = f(t);

            if (t < c)
            {
                if (yt < yc)
                {
                    b = c; yb = yc; c = t; yc = yt;
                }
                else if (yt > yc) { a = t; ya = yt; }
                else { a = t; ya = yt; b = c; yb = yc; c = (a + b) / 2; yc = f(c); }
            }
            else if (t > c)
            {
                if (yt < yc) { a = c; ya = yc; c = t; yc = yt; }
                else if (yt > yc) { b = t; yb = yt; }
                else
                {
                    a = c; ya = yc; b = t; yb = yt; c = (a + b) / 2; yc = f(c);
                }
            }
        }
        double x = (a + b) / 2;
        double y = f(x);
        Console.WriteLine($"Метод парабол: x={x:F5} y={y:F5}");
    }
}
