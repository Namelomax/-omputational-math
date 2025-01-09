using System;

    // Вычисление формулы f
    static double Function(double a, double b, double c)
    {
        return (10*c+Math.Sqrt(b)) / (a*a-b);
    }

    // Частная производная а
    static double PartialDerivativeA(Func<double, double, double, double> func, double a, double b, double c, double h = 0.0001)
    {
        return (func(a + h, b, c) - func(a - h, b, c)) / (2 * h);
    }

    // Частная производная b
    static double PartialDerivativeB(Func<double, double, double, double> func, double a, double b, double c, double h = 0.0001)
    {
        return (func(a, b + h, c) - func(a, b - h, c)) / (2 * h);
    }

    // Частная производная c
    static double PartialDerivativeC(Func<double, double, double, double> func, double a, double b, double c, double h = 0.0001)
    {
        return (func(a, b, c + h) - func(a, b, c - h)) / (2 * h);
    }

    //Вычисление дельта f - абсолютную погрешность
    static double DeltaF(double df_da, double df_db, double df_dc, double delta_a, double delta_b, double delta_c)
    {
        return Math.Abs(df_da) * delta_a + Math.Abs(df_db) * delta_b + Math.Abs(df_dc) * delta_c; ;
    }
        double a = 1.24734;
        double b = 0.346;
        double c = 0.051;
        double f = Function(a,b,c);

        double partialA = PartialDerivativeA(Function, a, b, c);
        double partialB = PartialDerivativeB(Function, a, b, c);
        double partialC = PartialDerivativeC(Function, a, b, c);

        double delta_f = DeltaF(partialA, partialB, partialC, 0.00001, 0.001, 0.001);
        double delta_f_relative = delta_f / f;
        double exp = Function(a,b,c)-Function(a+0.00001,b+0.001,c+0.001);
        Console.WriteLine($"f: {f}");
        Console.WriteLine($"Частная производная по a : {partialA}");
        Console.WriteLine($"Частная производная по b : {partialB}");
        Console.WriteLine($"Частная производная по c : {partialC}");
        Console.WriteLine($"Абсолютная погрешность: {delta_f}");
        Console.WriteLine($"Относительная  погрешность: {delta_f_relative}");
        Console.WriteLine($"Эксперементальное абсолютное: {Math.Abs(exp)}");
        Console.WriteLine($"Эксперементальное относительное: {Math.Abs(exp)/Function(a,b,c)}");