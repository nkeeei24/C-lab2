using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Program
    {
        private const int MaxFloors = 1000;

        public static void Main()
        {
            // Чтобы русский текст корректно отображался в терминале.
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                int choice = ReadInt("Ваш выбор", 0, 5);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        DemoTime();
                        break;
                    case 2:
                        DemoHouse();
                        break;
                    case 3:
                        DemoEmployees();
                        break;
                    case 4:
                        DemoImmutableHouse();
                        break;
                    case 5:
                        DemoPistol();
                        break;
                    case 0:
                        exit = true;
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine();
                    Console.Write("Нажмите Enter, чтобы вернуться в меню...");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("До свидания!");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("===== Лабораторная работа №2 (вариант 6) =====");
            Console.WriteLine("1. Время (задание 1.4)");
            Console.WriteLine("2. Дом (задание 1.5)");
            Console.WriteLine("3. Сотрудники и отделы (задания 2.4 и 3.4)");
            Console.WriteLine("4. Дом с неизменяемой этажностью (задание 4.3)");
            Console.WriteLine("5. Пистолет (задание 5.1)");
            Console.WriteLine("0. Выход");
        }

        private static void DemoTime()
        {
            Console.WriteLine("=== Задание 1.4. Время ===");

            int[] samples = { 10, 10000, 100000 };

            foreach (int seconds in samples)
            {
                Time time = new Time(seconds);
                Console.WriteLine($"{seconds} секунд -> {time}");
            }

            Console.WriteLine();
            Console.WriteLine("Попробуйте сами.");
            int userSeconds = ReadInt("Введите количество секунд", 0, int.MaxValue);
            Console.WriteLine($"{userSeconds} секунд -> {new Time(userSeconds)}");
        }

        private static void DemoHouse()
        {
            Console.WriteLine("=== Задание 1.5. Дом ===");

            int[] samples = { 1, 5, 23 };

            foreach (int floors in samples)
            {
                House house = new House(floors);
                Console.WriteLine(house);
            }

            Console.WriteLine();
            Console.WriteLine("Попробуйте сами.");
            int userFloors = ReadInt("Введите количество этажей", 1, MaxFloors);
            Console.WriteLine(new House(userFloors));
        }

        private static void DemoEmployees()
        {
            Console.WriteLine("=== Задания 2.4 и 3.4. Сотрудники и отделы ===");

            Department it = new Department("IT");
            Employee petrov = new Employee("Петров", it);
            Employee kozlov = new Employee("Козлов", it);
            Employee sidorov = new Employee("Сидоров", it);

            Console.WriteLine("Сотрудники созданы, начальник пока не назначен:");
            Console.WriteLine(petrov);
            Console.WriteLine(kozlov);
            Console.WriteLine(sidorov);

            Console.WriteLine();
            Console.WriteLine("Делаем Козлова начальником отдела IT:");
            it.Chief = kozlov;
            Console.WriteLine(petrov);
            Console.WriteLine(kozlov);
            Console.WriteLine(sidorov);

            Console.WriteLine();
            Console.WriteLine("Задание 3.4. Список сотрудников по ссылке на Сидорова:");
            Department sidorovDepartment = sidorov.Department;
            Console.WriteLine(sidorovDepartment);

            List<Employee> colleagues = sidorovDepartment.Employees;

            foreach (Employee employee in colleagues)
            {
                Console.WriteLine($"- {employee.Name}");
            }
        }

        private static void DemoImmutableHouse()
        {
            Console.WriteLine("=== Задание 4.3. Дом с неизменяемой этажностью ===");

            int[] samples = { 2, 35, 91 };

            foreach (int floors in samples)
            {
                House house = new House(floors);
                Console.WriteLine(house);
            }

            Console.WriteLine();
            House demoHouse = new House(2);
            Console.WriteLine($"Было: {demoHouse}");
            Console.WriteLine("Пробуем изменить количество этажей: demoHouse.Floors = 10;");

            // Эта строка не скомпилируется (ошибка CS0200): у свойства Floors нет set.
            // demoHouse.Floors = 10;

            Console.WriteLine($"Стало: {demoHouse}");
            Console.WriteLine("Присвоить новое значение нельзя: у свойства Floors нет set.");
            Console.WriteLine("Раскомментируйте строку в коде, чтобы увидеть ошибку компилятора.");
        }

        private static void DemoPistol()
        {
            Console.WriteLine("=== Задание 5.1. Пистолет ===");

            Pistol pistol = new Pistol(3);
            Console.WriteLine(pistol);

            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Выстрел {i}: ");
                pistol.Shoot();
            }

            Console.WriteLine(pistol);

            Console.WriteLine();
            Pistol defaultPistol = new Pistol();
            Console.WriteLine($"Пистолет без указания патронов: {defaultPistol}");
        }

        // Читает целое число из диапазона [min, max], пока пользователь не введёт корректное значение.
        private static int ReadInt(string prompt, int min, int max)
        {
            int value;

            Console.Write($"{prompt} (от {min} до {max}): ");

            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write($"Ошибка! Введите целое число от {min} до {max}: ");
            }

            return value;
        }
    }
}
