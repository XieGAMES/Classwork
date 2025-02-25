using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static Dictionary<string, List<double>> transactions = new Dictionary<string, List<double>>();

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Добро пожаловать в систему управления финансами!");
            Console.WriteLine("1. Добавить доход/расход");
            Console.WriteLine("2. Показать отчет");
            Console.WriteLine("3. Рассчитать баланс");
            Console.WriteLine("4. Прогноз на следующий месяц");
            Console.WriteLine("5. Статистика");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTransaction();
                    break;
                case 2:
                    PrintFinanceReport();
                    break;
                case 3:
                    CalculateBalance();
                    break;
                case 4:
                    PredictNextMonthExpenses();
                    break;
                case 5:
                    PrintStatistics();
                    break;
                case 6:
                    isRunning = false;
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddTransaction()
    {
        Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
        string category = Console.ReadLine();
        Console.Write("Введите сумму: ");
        double amount = double.Parse(Console.ReadLine());

        if (!transactions.ContainsKey(category))
        {
            transactions[category] = new List<double>();
        }
        transactions[category].Add(amount);
        Console.WriteLine("Запись добавлена.");
    }

    
    static void PrintFinanceReport()
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var category in transactions)
        {
            Console.WriteLine($"{category.Key}: {category.Value.Sum()} руб. - {category.Value.Count} операций");
        }
    }


    static void CalculateBalance()
    {
        double income = transactions.ContainsKey("Доход") ? transactions["Доход"].Sum() : 0;
        double expenses = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Sum());
        double balance = income - expenses;
        Console.WriteLine($"Текущий баланс: {balance} руб.");
    }

  
    static void PredictNextMonthExpenses()
    {
        double totalExpenses = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Sum());
        int totalMonths = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Count);
        double predictedExpenses = totalMonths > 0 ? totalExpenses / totalMonths : 0;
        Console.WriteLine($"Прогнозируемые расходы на следующий месяц: {predictedExpenses} руб.");
    }

    static void PrintStatistics()
    {
        var expenses = transactions.Where(t => t.Key != "Доход").ToDictionary(t => t.Key, t => t.Value.Sum());
        double totalExpenses = expenses.Sum(e => e.Value);

        Console.WriteLine("Статистика расходов:");
        Console.WriteLine($"Общая сумма расходов: {totalExpenses} руб.");

        var mostExpensiveCategory = expenses.OrderByDescending(e => e.Value).FirstOrDefault();
        Console.WriteLine($"Самая затратная категория: {mostExpensiveCategory.Key} ({mostExpensiveCategory.Value} руб.)");

        var mostFrequentCategory = transactions.OrderByDescending(t => t.Value.Count).FirstOrDefault();
        Console.WriteLine($"Самая частая категория: {mostFrequentCategory.Key} ({mostFrequentCategory.Value.Count} операций)");

        Console.WriteLine("Процентное распределение расходов:");
        foreach (var category in expenses)
        {
            double percentage = (category.Value / totalExpenses) * 100;
            Console.WriteLine($"{category.Key}: {category.Value} руб. ({percentage:F2}%)");
        }
    }
}