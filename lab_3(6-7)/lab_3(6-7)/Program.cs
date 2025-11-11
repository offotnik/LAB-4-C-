using lab_3_6_7_;

class Program
{
    static void Main(string[] args)
    {
        TestUnaryOperators();
        TestConversionOperators();
        TestBinaryOperators();

        Console.WriteLine("Все тесты пройдены успешно!");
    }

    static void TestUnaryOperators()
    {
        Console.WriteLine("Тестирование унарных операторов:");

        // Тест оператора ++
        var eq1 = new OverrideMet(1, 2, 3);
        Console.WriteLine($"Исходное уравнение: {eq1}");
        eq1++;
        Console.WriteLine($"После ++: {eq1}");

        // Тест оператора --
        var eq3 = new OverrideMet(4, 5, 6);
        Console.WriteLine($"Исходное уравнение: {eq3}");
        eq3--;
        Console.WriteLine($"После --: {eq3}");

        Console.WriteLine();
    }

    static void TestConversionOperators()
    {
        Console.WriteLine("Тестирование операторов приведения:");

        // Тест неявного приведения к double (дискриминант)
        var eq1 = new OverrideMet(1, 5, 6); // x^2 + 5x + 6 = 0
        double discriminant = eq1; // Неявное приведение
        Console.WriteLine($"Уравнение: {eq1}");
        Console.WriteLine($"Дискриминант: {discriminant} (ожидается: 1)");

        // Тест явного приведения к bool (существуют ли корни)
        var eq2 = new OverrideMet(1, 2, 3); // x^2 + 2x + 3 = 0 (нет корней)
        bool hasRoots = (bool)eq2; // Явное приведение
        Console.WriteLine($"Уравнение: {eq2}");
        Console.WriteLine($"Есть корни: {hasRoots} (ожидается: False)");

        var eq3 = new OverrideMet(1, -3, 2); // x^2 - 3x + 2 = 0 (есть корни)
        bool hasRoots2 = (bool)eq3; // Явное приведение
        Console.WriteLine($"Уравнение: {eq3}");
        Console.WriteLine($"Есть корни: {hasRoots2} (ожидается: True)");

        Console.WriteLine();
    }

    static void TestBinaryOperators()
    {
        Console.WriteLine("Тестирование бинарных операторов:");

        // Тест оператора ==
        var eq1 = new OverrideMet(1, 2, 3);
        var eq2 = new OverrideMet(1, 2, 3);
        var eq3 = new OverrideMet(4, 5, 6);

        Console.WriteLine($"eq1: {eq1}");
        Console.WriteLine($"eq2: {eq2}");
        Console.WriteLine($"eq3: {eq3}");
        Console.WriteLine($"eq1 == eq2: {eq1 == eq2} (ожидается: True)");
        Console.WriteLine($"eq1 == eq3: {eq1 == eq3} (ожидается: False)");

        // Тест оператора !=
        Console.WriteLine($"eq1 != eq2: {eq1 != eq2} (ожидается: False)");
        Console.WriteLine($"eq1 != eq3: {eq1 != eq3} (ожидается: True)");

        // Тест с null
        OverrideMet eq4 = null;
        OverrideMet eq5 = null;
        Console.WriteLine($"null == null: {eq4 == eq5} (ожидается: True)");
        Console.WriteLine($"eq1 == null: {eq1 == null} (ожидается: False)");
        Console.WriteLine($"null == eq1: {eq4 == eq1} (ожидается: False)");

        Console.WriteLine();
    }
}