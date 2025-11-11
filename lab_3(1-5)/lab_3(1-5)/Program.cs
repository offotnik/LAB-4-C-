using lab_3_1_5_;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ТЕСТИРОВАНИЕ МЕТОДОВ ИЗ METHODS.CS ===\n");

        TestHasDublicates();
        TestDeleteFirst();
        TestMusicPreferences();
        TestFindUniqueVowels();

        Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
    }

    static void TestHasDublicates()
    {
        Console.WriteLine("1. ТЕСТ МЕТОДА HASDUBLICATES");
        Console.WriteLine("=============================");

        // Тест 1: Пустой список
        Console.WriteLine("\nТест 1: Пустой список");
        var emptyList = new List<int>();
        Console.WriteLine($"Результат: {Methods.HasDublicates(emptyList)} (ожидается: False)");

        // Тест 2: Один элемент
        Console.WriteLine("\nТест 2: Один элемент");
        var singleItem = new List<string> { "one" };
        Console.WriteLine($"Результат: {Methods.HasDublicates(singleItem)} (ожидается: False)");

        // Тест 3: Нет дубликатов
        Console.WriteLine("\nТест 3: Нет дубликатов");
        var noDupes = new List<int> { 1, 2, 3, 4 };
        Console.WriteLine($"Результат: {Methods.HasDublicates(noDupes)} (ожидается: False)");

        // Тест 4: Есть дубликаты чисел
        Console.WriteLine("\nТест 4: Есть дубликаты чисел");
        var numberDupes = new List<int> { 1, 2, 3, 2, 5 };
        Console.WriteLine($"Результат: {Methods.HasDublicates(numberDupes)} (ожидается: True)");

        // Тест 5: Есть дубликаты строк
        Console.WriteLine("\nТест 5: Есть дубликаты строк");
        var stringDupes = new List<string> { "apple", "banana", "apple", "orange" };
        Console.WriteLine($"Результат: {Methods.HasDublicates(stringDupes)} (ожидается: True)");

        Console.WriteLine("\n" + new string('-', 50));
    }

    static void TestDeleteFirst()
    {
        Console.WriteLine("\n2. ТЕСТ МЕТОДА DELETEFIRST");
        Console.WriteLine("===========================");

        // Тест 1: Удаление существующего элемента
        Console.WriteLine("\nТест 1: Удаление существующего элемента");
        var linkedList = new LinkedList<string>();
        linkedList.AddLast("first");
        linkedList.AddLast("second");
        linkedList.AddLast("third");

        Console.WriteLine("До удаления:");
        foreach (var item in linkedList)
            Console.WriteLine($"  - {item}");

        var result = Methods.DeleteFirst(linkedList, "second");

        Console.WriteLine("После удаления 'second':");
        if (result != null)
        {
            foreach (var item in result)
                Console.WriteLine($"  - {item}");
        }

        // Тест 2: Попытка удаления несуществующего элемента
        Console.WriteLine("\nТест 2: Попытка удаления несуществующего элемента");
        var result2 = Methods.DeleteFirst(linkedList, "nonexistent");
        Console.WriteLine($"Результат: {(result2 == null ? "null" : "список")}");

        // Тест 3: Удаление из пустого списка
        Console.WriteLine("\nТест 3: Удаление из пустого списка");
        var emptyList = new LinkedList<int>();
        var result3 = Methods.DeleteFirst(emptyList, 5);
        Console.WriteLine($"Результат: {(result3 == null ? "null" : "список")}");

        Console.WriteLine("\n" + new string('-', 50));
    }

    static void TestMusicPreferences()
    {
        Console.WriteLine("\n3. ТЕСТ АНАЛИЗА МУЗЫКАЛЬНЫХ ПРЕДПОЧТЕНИЙ");
        Console.WriteLine("========================================");

        // Тест 1: Базовый тест
        Console.WriteLine("\nТест 1: Базовый тест с тремя меломанами");

        HashSet<string> allTracks = new HashSet<string> { "Трек1", "Трек2", "Трек3", "Трек4", "Трек5", "Трек6" };

        HashSet<string> man1 = new HashSet<string> { "Трек1", "Трек2", "Трек3" };
        HashSet<string> man2 = new HashSet<string> { "Трек2", "Трек4", "Трек6" };
        HashSet<string> man3 = new HashSet<string> { "Трек2", "Трек5" };

        List<HashSet<string>> preferences = new List<HashSet<string>> { man1, man2, man3 };

        var result = Methods.AnalyzePreferences(allTracks, preferences);

        Methods.PrintResult("Нравятся всем меломанам", result.likedByAll);
        Methods.PrintResult("Нравятся некоторым меломанам", result.likedBySome);
        Methods.PrintResult("Не нравятся никому", result.likedByNone);

        // Тест 2: Пустые предпочтения
        Console.WriteLine("\nТест 2: Пустые предпочтения");
        var emptyResult = Methods.AnalyzePreferences(allTracks, new List<HashSet<string>>());

        Methods.PrintResult("Нравятся всем (пусто)", emptyResult.likedByAll);
        Methods.PrintResult("Нравятся некоторым (пусто)", emptyResult.likedBySome);
        Methods.PrintResult("Не нравятся никому (все треки)", emptyResult.likedByNone);

        Console.WriteLine("\n" + new string('-', 50));
    }

    static void TestFindUniqueVowels()
    {
        Console.WriteLine("\n4. ТЕСТ ПОИСКА УНИКАЛЬНЫХ ГЛАСНЫХ");
        Console.WriteLine("==================================");

        HashSet<char> russianVowels = new HashSet<char>
        {
            'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
            'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я'
        };

        // Тест 1: Обычный текст
        Console.WriteLine("\nТест 1: Обычный текст");
        string text1 = "дом сад огород парк лес";
        var result1 = Methods.FindUniqueVowels(text1, russianVowels);

        Console.WriteLine($"Текст: '{text1}'");
        Console.WriteLine("Уникальные гласные (входят не более чем в одно слово):");
        foreach (char vowel in result1)
        {
            Console.WriteLine($"  - '{vowel}'");
        }

        // Тест 2: Текст с повторяющимися гласными
        Console.WriteLine("\nТест 2: Текст с повторяющимися гласными");
        string text2 = "мама мыла раму";
        var result2 = Methods.FindUniqueVowels(text2, russianVowels);

        Console.WriteLine($"Текст: '{text2}'");
        Console.WriteLine("Уникальные гласные:");
        foreach (char vowel in result2)
        {
            Console.WriteLine($"  - '{vowel}'");
        }

        // Тест 3: Текст с разным регистром
        Console.WriteLine("\nТест 3: Текст с разным регистром");
        string text3 = "Анна иван Олег";
        var result3 = Methods.FindUniqueVowels(text3, russianVowels);

        Console.WriteLine($"Текст: '{text3}'");
        Console.WriteLine("Уникальные гласные:");
        foreach (char vowel in result3)
        {
            Console.WriteLine($"  - '{vowel}'");
        }

        Console.WriteLine("\n" + new string('-', 50));
    }
}