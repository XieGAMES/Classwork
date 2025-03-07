using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика8
{
    class Program
    {

        static int health;
        static int maxHealth;
        static int gold;
        static int potions;
        static int arrows;
        static string weapon;
        static int swordDamage;

        static Random random = new Random();

        static void Main(string[] args)
        {
            InitializeGame();
            StartGame();

            Console.WriteLine("Игра окончена!");
        }

        static void InitializeGame()
        {
            health = 100;
            maxHealth = 100;
            gold = 10;
            potions = 2;
            arrows = 5;
            weapon = "Меч и лук";
            swordDamage = 10;

            Console.WriteLine("Добро пожаловать в Числовой Квест ULTIMATE!");
        }

        static void StartGame()
        {
            for (int roomNumber = 1; roomNumber <= 15; roomNumber++)
            {
                Console.WriteLine($"\nКомната {roomNumber}");
                ProcessRoom(roomNumber);

                if (health <= 0)
                {
                    Console.WriteLine("Вы погибли!");
                    EndGame(false);
                    return;
                }
            }

            Console.WriteLine("\nВы достигли последней комнаты! Готовьтесь к битве с боссом!");
            FightBoss();
        }

        static void ProcessRoom(int roomNumber)
        {
            int eventType = random.Next(0, 5);

            switch (eventType)
            {
                case 0:
                    int monsterHealth = random.Next(20, 51);
                    int monsterAttack = random.Next(5, 16);
                    FightMonster(monsterHealth, monsterAttack);
                    break;
                case 1:
                    TriggerTrap();
                    break;
                case 2:
                    OpenChest();
                    break;
                case 3:
                    VisitMerchant();
                    break;
                case 4:
                    if (random.Next(0, 2) == 0)
                    {
                        VisitAltar();
                    }
                    else
                    {
                        MeetDarkMage();
                    }
                    break;
            }
        }

        static void FightMonster(int monsterHP, int monsterAttack)
        {
            Console.WriteLine($"Вы столкнулись с монстром! Здоровье: {monsterHP}, Атака: {monsterAttack}");

            while (monsterHP > 0 && health > 0)
            {
                Console.WriteLine("\nВаши действия:");
                Console.WriteLine("1. Атаковать мечом");
                Console.WriteLine("2. Атаковать стрелой");
                Console.WriteLine("3. Выпить зелье");
                Console.WriteLine("4. Показать характеристики");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        int damage = random.Next(swordDamage, swordDamage + 11);
                        Console.WriteLine($"Вы нанесли монстру {damage} урона мечом.");
                        monsterHP -= damage;
                        Console.WriteLine($"У монстра осталось {monsterHP} здоровья.");
                        break;
                    case "2":
                        if (arrows > 0)
                        {
                            arrows--;
                            int arrowDamage = random.Next(5, 16);
                            Console.WriteLine($"Вы нанесли монстру {arrowDamage} урона стрелой.");
                            monsterHP -= arrowDamage;
                            Console.WriteLine($"У монстра осталось {monsterHP} здоровья.");
                        }
                        else
                        {
                            Console.WriteLine("У вас нет стрел!");
                            continue;
                        }
                        break;
                    case "3":
                        UsePotion();
                        break;
                    case "4":
                        ShowStats();
                        continue;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        continue;
                }

                if (monsterHP > 0)
                {
                    Console.WriteLine($"Монстр атакует вас и наносит {monsterAttack} урона.");
                    health -= monsterAttack;
                    Console.WriteLine($"У вас осталось {health} здоровья.");
                }
            }

            if (monsterHP <= 0)
            {
                Console.WriteLine("Вы победили монстра!");
                gold += random.Next(1, 6);
                Console.WriteLine($"Вы нашли {gold - (gold - random.Next(1, 6))} золота. Теперь у вас {gold} золота.");
            }
            else
            {
                Console.WriteLine("Вы погибли!");
                EndGame(false);
            }
        }

        static void TriggerTrap()
        {
            int damage = random.Next(5, 21);
            Console.WriteLine($"Вы попали в ловушку и потеряли {damage} здоровья.");
            health -= damage;
            Console.WriteLine($"У вас осталось {health} здоровья.");
        }

        static void OpenChest()
        {
            if (random.Next(0, 5) == 0)
            {
                Console.WriteLine("Вы открыли проклятый сундук!");
                int healthLoss = 10;
                maxHealth -= healthLoss;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
                Console.WriteLine($"Ваше максимальное здоровье уменьшилось на {healthLoss} и теперь равно {maxHealth}.");
            }
            else
            {
                Console.WriteLine("Вы открыли сундук!");
                int itemType = random.Next(0, 3);

                switch (itemType)
                {
                    case 0:
                        int foundGold = random.Next(5, 16);
                        gold += foundGold;
                        Console.WriteLine($"Вы нашли {foundGold} золота. Теперь у вас {gold} золота.");
                        break;
                    case 1:
                        potions++;
                        Console.WriteLine($"Вы нашли зелье! Теперь у вас {potions} зелий.");
                        break;
                    case 2:
                        int foundArrows = random.Next(3, 8);
                        arrows += foundArrows;
                        Console.WriteLine($"Вы нашли {foundArrows} стрел! Теперь у вас {arrows} стрел.");
                        break;
                }
            }
        }

        static void VisitMerchant()
        {
            Console.WriteLine("Вы встретили торговца.");
            Console.WriteLine("Что хотите купить?");
            Console.WriteLine("1. Зелье (10 золота)");
            Console.WriteLine("2. Стрелы (5 золота за 3 штуки)");
            Console.WriteLine("3. Уйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (gold >= 10)
                    {
                        gold -= 10;
                        potions++;
                        Console.WriteLine("Вы купили зелье. Теперь у вас {potions} зелий и {gold} золота.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота.");
                    }
                    break;
                case "2":
                    if (gold >= 5)
                    {
                        gold -= 5;
                        arrows += 3;
                        Console.WriteLine("Вы купили 3 стрелы. Теперь у вас {arrows} стрел и {gold} золота.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Вы ушли от торговца.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void VisitAltar()
        {
            Console.WriteLine("Вы нашли алтарь.");
            Console.WriteLine("Пожертвовать 10 золота для усиления?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (gold >= 10)
                    {
                        gold -= 10;
                        swordDamage += 5;
                        health += 20;
                        if (health > maxHealth)
                        {
                            health = maxHealth;
                        }
                        Console.WriteLine($"Вы пожертвовали 10 золота. Урон меча увеличен на 5 (теперь {swordDamage}), здоровье восстановлено на 20 (теперь {health}).");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Вы покинули алтарь.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void MeetDarkMage()
        {
            Console.WriteLine("Вы встретили темного мага.");
            Console.WriteLine("Маг предлагает сделку: пожертвовать 10 здоровья в обмен на 2 зелья и 5 стрел.");
            Console.WriteLine("1. Принять сделку");
            Console.WriteLine("2. Отказаться");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (health >= 10)
                    {
                        health -= 10;
                        potions += 2;
                        arrows += 5;
                        Console.WriteLine($"Вы пожертвовали 10 здоровья. Теперь у вас {health} здоровья, {potions} зелий и {arrows} стрел.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно здоровья.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Вы отказались от сделки.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void UsePotion()
        {
            if (potions > 0)
            {
                potions--;
                int healAmount = 30;
                health += healAmount;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
                Console.WriteLine($"Вы использовали зелье и восстановили {healAmount} здоровья. Теперь у вас {health} здоровья и {potions} зелий.");
            }
            else
            {
                Console.WriteLine("У вас нет зелий!");
            }
        }

        static void ShowStats()
        {
            Console.WriteLine("\nХарактеристики");
            Console.WriteLine($"Здоровье: {health}/{maxHealth}");
            Console.WriteLine($"Золото: {gold}");
            Console.WriteLine($"Зелья: {potions}");
            Console.WriteLine($"Стрелы: {arrows}");
            Console.WriteLine($"Оружие: {weapon} (урон мечом: {swordDamage})");
            
        }

        static void FightBoss()
        {
            int bossHealth = 100;
            Console.WriteLine("Вы столкнулись с БОССОМ! Здоровье босса: 100");

            int turnCounter = 0;
            while (bossHealth > 0 && health > 0)
            {
                turnCounter++;
                Console.WriteLine("\nВаши действия:");
                Console.WriteLine("1. Атаковать мечом");
                Console.WriteLine("2. Атаковать стрелой");
                Console.WriteLine("3. Выпить зелье");
                Console.WriteLine("4. Показать характеристики");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int damage = random.Next(swordDamage, swordDamage + 11);
                        Console.WriteLine($"Вы нанесли боссу {damage} урона мечом.");
                        bossHealth -= damage;
                        Console.WriteLine($"У босса осталось {bossHealth} здоровья.");
                        break;
                    case "2":
                        if (arrows > 0)
                        {
                            arrows--;
                            int arrowDamage = random.Next(5, 16);
                            Console.WriteLine($"Вы нанесли боссу {arrowDamage} урона стрелой.");
                            bossHealth -= arrowDamage;
                            Console.WriteLine($"У босса осталось {bossHealth} здоровья.");
                        }
                        else
                        {
                            Console.WriteLine("У вас нет стрел!");
                            continue;
                        }
                        break;
                    case "3":
                        UsePotion();
                        break;
                    case "4":
                        ShowStats();
                        continue;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        continue;
                }

                if (bossHealth > 0)
                {
                    Console.WriteLine($"Монстр атакует вас и наносит {random.Next(15, 26)} урона.");
                    health -= random.Next(15, 26);
                    Console.WriteLine($"У вас осталось {health} здоровья.");
                }
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Вы победили БОССА! Вы прошли игру!");
                EndGame(true);
            }
            else
            {
                Console.WriteLine("Вы погибли!");
                EndGame(false);
            }
        }

        static void EndGame(bool isWin)
        {
            if (isWin)
            {
                Console.WriteLine("Поздравляем! Вы выиграли игру!");
            }
            else
            {
                Console.WriteLine("Игра окончена. Попробуйте еще раз!");
            }
        }
    }
}
