using System;

class Program
{
    static void Main(string[] args)
    {
     
        Calcul(5, 3);
        Calcul(5, 3, 2);

        
        Console.WriteLine($"Min: {Min(5, 3)}");
        Console.WriteLine($"Max: {Max(5, 3)}");

        Console.WriteLine($"палидром?{IsPalindrome("level")}");
        Console.WriteLine($"палидром? {IsPalindrome("hello")}");

        Console.WriteLine($"факториал 5: {Factorial(5)}");

     
        Console.WriteLine($"среднее {Average(2, 4, 6)}");

        
        Console.WriteLine($"индекс е{FindChar("hello", 'e')}");
        Console.WriteLine($"индекс а{FindChar("hello", 'a')}");

       
        Console.WriteLine($"пароль {GeneratePassword(6)}");

        
        Console.WriteLine($" цельсия температура в фаренгейт {CelsiusToFahrenheit(0)}");
        Console.WriteLine($": фаренгейт в цельсия {FahrenheitToCelsius(32)}");

      
        Console.WriteLine($"перестановка {ReverseWords("Hello world!")}");


        MultiplicationTable(5);
    }

    // 1. Сумма двух и трёх чисел
    static void Calcul(int a, int b)
    {
        Console.WriteLine($"Sum: {a + b}, Difference: {a - b}, Product: {a * b}, Quotient: {a / b}");
    }

    static void Calcul(int a, int b, int c)
    {
        Console.WriteLine($"Sum: {a + b + c}, Difference: {a - b - c}, Product: {a * b * c}, Quotient: {a / b / c}");
    }

    // 2. Минимальное и максимальное значение
    static int Min(int a, int b)
    {
        return a < b ? a : b;
    }

    static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    // 3. Проверка на палиндром
    static bool IsPalindrome(string str)
    {
        int length = str.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (str[i] != str[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    // 4. Факториал числа
    static int Factorial(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // 5. Среднее арифметическое
    static double Average(int a, int b, int c)
    {
        return (a + b + c) / 3.0;
    }

    // 6. Поиск символа в строке
    static int FindChar(string text, char c)
    {
        return text.IndexOf(c);
    }

    // 7. Генерация случайного пароля
    static string GeneratePassword(int length)
    {
        Random random = new Random();
        string password = "";
        for (int i = 0; i < length; i++)
        {
            password += random.Next(0, 10).ToString();
        }
        return password;
    }

    // 8. Конвертация температуры
    static double CelsiusToFahrenheit(double c)
    {
        return c * 9 / 5 + 32;
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    // 9. Перестановка слов в предложении
    static string ReverseWords(string sentence)
    {
        string[] words = sentence.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    // 10. Таблица умножения для числа
    static void MultiplicationTable(int n)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} x {i} = {n * i}");
        }
    }
}