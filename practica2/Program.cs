using System;
using System.Collections.Generic;
using System.Linq;

class FinanceManager
{
    private Dictionary<string, List<double>> transactions;

    public FinanceManager()
    {
        transactions = new Dictionary<string, List<double>>();
    }

    
    public void AddTransaction(string category, double amount)
    {
        if (!transactions.ContainsKey(category))
        {
            transactions[category] = new List<double>();
        }
        transactions[category].Add(amount);
        Console.WriteLine("Запись добавлена.");
    }
    public void PrintFinanceReport()
    {
        Console.WriteLine("Финансовый отчет:");
        foreach (var category in transactions)
        {
            Console.WriteLine($"{category.Key}: {category.Value.Sum()} руб. - {category.Value.Count} операций");
        }
    }

    
    public double CalculateBalance()
    {
        double income = transactions.ContainsKey("Доход") ? transactions["Доход"].Sum() : 0;
        double expenses = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Sum());
        return income - expenses;
    }

    public double GetAverageExpense(string category)
    {
        if (transactions.ContainsKey(category) && transactions[category].Count > 0)
        {
            return transactions[category].Average();
        }
        return 0;
    }

    public double PredictNextMonthExpenses()
    {
        double totalExpenses = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Sum());
        int totalMonths = transactions.Where(t => t.Key != "Доход").Sum(t => t.Value.Count);
        return totalMonths > 0 ? totalExpenses / totalMonths : 0;
    }

    public void PrintStatistics()
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

class Program
{
    static void Main(string[] args)
    {
        FinanceManager manager = new FinanceManager();
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
                    Console.Write("Введите категорию (Доход, Продукты, Транспорт, Развлечения): ");
                    string category = Console.ReadLine();
                    Console.Write("Введите сумму: ");
                    double amount = double.Parse(Console.ReadLine());
                    manager.AddTransaction(category, amount);
                    break;
                case 2:
                    manager.PrintFinanceReport();
                    break;
                case 3:
                    Console.WriteLine($"Текущий баланс: {manager.CalculateBalance()} руб.");
                    break;
                case 4:
                    Console.WriteLine($"Прогнозируемые расходы на следующий месяц: {manager.PredictNextMonthExpenses()} руб.");
                    break;
                case 5:
                    manager.PrintStatistics();
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
}