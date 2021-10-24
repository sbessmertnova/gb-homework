using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson6
{
    public delegate double Fun(double x, double y);
    public delegate double Fun2(double x);
    
    class Program
    {
        //Бессмертнова
        #region Задача№1
        /// <summary>
        /// Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
        /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        /// </summary>
        /// 
        static void Task1()
        {
            //Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции Sin:");
            Table(new Fun(MyASin), -2, 2);
            //Используем созданный метод
            Console.WriteLine("Таблица функции Sin:");
            Table(MyASin, -2, 2);
            //Используем анонимный метод
            Table(delegate (double x, double y) { return y * x * x; }, 0, 3);

        }
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        /// <summary>
        /// обертка для метода Math.Sin
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double MySin(double x)
        {
            return Math.Sin(x);
        }
        /// <summary>
        /// метод для передачи его в качестве параметра в Table
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double MyASin(double x, double a)
        {
            return a* MySin(x);
        }
        #endregion
        #region Задача№2
        /// <summary>
        /// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        /// а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив(или список) 
        /// делегатов, в котором хранятся различные функции.
        /// б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр (с использованием модификатора out).
        /// </summary>
        /// 
        static void Task2()
        {
            const string fileName = "data.bin";
            Fun2[] Funcs = new Fun2[] 
            {
                delegate (double x) { return x * x - 50 * x + 10; },
                delegate (double x) { return x * x; },
                delegate (double x) { return Math.Exp(x); },
                delegate (double x) { return Math.Sqrt(x); },
            };
            Console.Write("Обозначьте отрезок. Введите первое число: ");
            var startingRange = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            var endingRange = int.Parse(Console.ReadLine());

                Console.Write("Выберите функцию: \n1 - return x * x - 50 * x + 10;  \n2 - return x*x; " +
                    "\n3 - return Math.Exp(x); \n4 - Math.Sqrt(x); " +
                    "\nВведите соответствующее число: ");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        SaveFunc(Funcs[0], fileName, startingRange, endingRange, 0.5);
                        break;
                    case 2:
                        Console.Clear();
                        SaveFunc(Funcs[1], fileName, startingRange, endingRange, 0.5);
                        break;
                    case 3:
                        Console.Clear();
                        SaveFunc(Funcs[2], fileName, startingRange, endingRange, 0.5);
                        break;
                    case 4:
                        Console.Clear();
                        SaveFunc(Funcs[3], fileName, startingRange, endingRange, 0.5);
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректное значение. Попробуйте снова");
                        break;
                }

            Console.WriteLine($"Все числа: {string.Join(' ', Load(fileName, out var min))},\nМинимальное число:{min}");
            Console.ReadKey();
        }
        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(Fun2 F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);//создание нового файла (если файл с таким имененм есть, он удаляется), только запись
            BinaryWriter bw = new BinaryWriter(fs);//выходной поток
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);//открывается и читается файл (только чтение)
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            var values = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                values.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return values;
        }

    
    #endregion
    #region Задача№3
    /// <summary>
    /// Переделать программу Пример использования коллекций для решения следующих задач:
    /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    /// в) отсортировать список по возрасту студента;
    /// г) *отсортировать список по курсу и возрасту студента;
    /// </summary>
    /// 
    static void Task3()
        {
        }
        #endregion
        static void Main(string[] args)
        {
            bool f = true;
            while (f)
            {
                Console.Write("Задача №1 - 1;  \nЗадача №2 - 2; \nЗадача №3 - 3; " +
                    "\nРешение какой задачи запустить? Введите соответствующее число: ");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        Console.WriteLine("Выполнение пункста первой задачи.");
                        Task1();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выполнение второй задачи");
                        Task2();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выполнение третьей задачи. ");
                        Task3();
                        break;
                    case 0:
                        Console.WriteLine("Завершение");
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                        break;
                }
            }
        }
    }
}
