using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace practic_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Мечта о автомате по ОАИП ", "Айдар Идиятуллин", 5);
            book1.PrintInfo();
            Student student1 = new Student("Айдар", 18, "221");
            student1.ShowInfo();
            Student student2 = new Student("Айдар", 18);
            student2.ShowInfo();
            Car myCar = new Car("Mercedes", 1000);
            myCar.Drive(200);
            myCar.ShowMileage();
            Rectangle rect = new Rectangle(5, 10);
            rect.PrintInfo();
            BankAccount myAccount = new BankAccount(1000);
            myAccount.Deposit(500);
            myAccount.Withdraw(200);
            myAccount.ShowBalance();

        }
    }
    //1
    class Book
    {
        string Title;
        string Author;
        int Pages;

        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;

        }
        public void PrintInfo()
        {
            Console.WriteLine($"Книга: {Title},Автор: {Author}, страниц: {Pages}");
        }
    }
    //2
    class Student
    {
        string Name;
        int Age;
        string Group = "Неизвестная группа";
        public Student(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;

        }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Студент: {Name}, {Age}, {Group}");
        }
    }
    //3
    class Car
    {
        string Brand;
        int Mileage;
        public Car(string brand, int mileage)
        {
            Brand = brand;
            Mileage = mileage;
        }
        public void Drive(int distance)
        {
            Mileage += distance;
        }
        public void ShowMileage()
        {
            Console.WriteLine($"Марка: {Brand},Пробег: {Mileage}");
        }
    }
    //4
    public class Rectangle
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int GetArea()
        {
            return width * height;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Ширина: {width}, Высота: {height}, Площадь: {GetArea()}");
        }
    }
    //5
    public class BankAccount
    {
        private int balance;

        public BankAccount(int initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Текущий баланс: {balance} руб.");
        }
    }
}

