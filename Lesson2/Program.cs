using Sample01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        //Бессмертнова
        #region Задание №1
        /// <summary>
        /// Задача 1 Написать метод, возвращающий минимальное из трёх чисел.
        /// </summary>
        static void Task1()
        {
             int ReturnMinNumber(int firstNumber, int secondNumber, int thirdNumber)
            {
                if (firstNumber < secondNumber && firstNumber < thirdNumber)
                {
                    return firstNumber;
                }
                else if (secondNumber < firstNumber && secondNumber < thirdNumber)
                {
                    return secondNumber;
                }
                else return thirdNumber; 
            }
            Console.WriteLine($"Наименьшее число - {ReturnMinNumber(34, 56, 12)}");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №2
        /// <summary>
        /// Задача 2 Написать метод подсчета количества цифр числа
        /// </summary>
        static void Task2()
        {
            int Counter (int number)
            {
                return $"{number}".Length;
            }
            ;
            Console.WriteLine($"Число состоит из {Counter(9842)} цифр.");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №3
        /// <summary>
        /// Задача 3  С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел
        /// </summary>
        static void Task3()
        {
            int GetNumberFromUser ()
            {
                Console.WriteLine("Введите число. Для остановки программы введите .\"0\"");
                 return int.Parse(Console.ReadLine());
            }
            int userNumber = GetNumberFromUser();
            int summ = 0;
            while (userNumber!=0)
            {
                if (userNumber%2==1)
                {
                    userNumber += summ;
                    summ = userNumber;
                }
                userNumber = GetNumberFromUser();
            }
            Console.WriteLine($"Сумма всех нечетных чисел равна {summ}");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №4
        /// <summary>
        /// Задача 4 Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
        /// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
        /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
        /// С помощью цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        static void Task4()
        {
            bool CheckLoginAndPassword(string login, string password)
            {
                return login == "root" && password == "GeekBrains";
            }
            int tryCounter = 0;
            int maxTry = 3;
            bool valid;
            do
            {
                Console.Write("Введите логин: ");
                string loginFromUser = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string passwordFromUser = Console.ReadLine();
                valid = CheckLoginAndPassword(loginFromUser, passwordFromUser);
                tryCounter += 1;
                if (valid)
                {
                    Console.WriteLine("Вы ввели верные креды. Добро пожаловать!");
                }
                else if(tryCounter < maxTry)
                {
                    Console.WriteLine($"Логин и/или пароль неверные. Попробуйте снова. Попыток осталось: {(maxTry - tryCounter)}");
                }
                else
                {
                    Console.WriteLine("Вы исчерпали 3 попытки. Вход невозможен.");

                }
            } while (!valid && tryCounter < maxTry);
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №5-a
        /// <summary>
        /// 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        /// </summary>
        static void Task5A()
        {
            HelperMethods.EstimateBodyMassIndex(false);            
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №5-б
        /// <summary>
        /// 5. б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// </summary>
        static void Task5B()
        {
            HelperMethods.EstimateBodyMassIndex();
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задание №6
        /// <summary>
        /// *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
        /// «Хорошим» называется число, которое делится на сумму своих цифр.
        /// Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
        /// </summary>
        static void Task6 ()
        {
            DateTime start = DateTime.Now;
            int number = 1;
            int amount = 0;
            do
            { 
                int degitSumm = DigitSummCounter(number);
                if (number%degitSumm == 0)
                {
                    amount++;
                }
                number++;
            } while (number< 1000000000);
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Количество .\"хороших.\" чисел - {amount}, время выполнения программы - {(finish - start)}");
            Console.ReadKey();
            Console.Clear();
        }
        public static int DigitSummCounter(int number)
        {
            int digit = 0;
            while (number > 0)
            {
                digit += number % 10;
                number /= 10;
            }
            return digit;
        }
        #endregion
        #region Задание №7-а
        /// <summary>
        /// 7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        /// </summary>
        static void Task7A()
        {
            DisplayRangeOfNumbers(1, 10);
            Console.ReadKey();
            Console.Clear();
        }
        static void DisplayRangeOfNumbers(int a, int b)
        {
            Console.Write("{0,5}", a);
            if (a < b)
            {
                DisplayRangeOfNumbers(a + 1, b);
            }
        }
        #endregion
        #region Задание №7-б
        /// <summary>
        /// 7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b
        /// </summary>
        static void Task7B()
        {
            Console.WriteLine($"Сумма чисел от a до d: {CounterRangeOfNumbers(1, 5)}");
            Console.ReadKey();
            Console.Clear();
        }
        static int CounterRangeOfNumbers(int a, int b)
        {
            return a==b
                ? a 
                : b + CounterRangeOfNumbers(a, b-1);
        }
        #endregion

        static void Main(string[] args)
        {
            
            bool f = true;
            while (f)
            {
                Console.Write("Задача №1 - 1;  \nЗадача №2 - 2; \nЗадача №3 - 3;  \nЗадача №4 - 4;  \nЗадача №5 - 5; \nЗадача №6 - 6; \nЗадача №7 - 7;" +
                    "\nРешение какой задачи запустить? Введите соответствующее число: ");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        Console.WriteLine("Выполнение первой задачи. ");
                        Task1();
                        break;
                    case 2:
                        Console.WriteLine("Выполнение второй задачи. ");
                        Task2();
                        break;
                    case 3:
                        Console.WriteLine("Выполнение третьей задачи. ");
                        Task3();
                        break;
                    case 4:
                        Console.WriteLine("Выполнение четвертой задачи");
                        Task4();
                        break;
                    case 5:
                            Console.Write("\n5а - 1; \n5б - 2; " +
                                "\nВыберите подпункт пятой задачи: ");
                            int fiveTaskNumber = int.Parse(Console.ReadLine());
                            switch (fiveTaskNumber)
                            {
                                case 1:
                                    Console.WriteLine("Выполнение пункта А пятой задачи. ");
                                    Task5A();
                                    break;
                                case 2:
                                    Console.WriteLine("Выполнение пункта Б пятой задачи. ");
                                    Task5B();
                                    break;
                                default:
                                    Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                    break;
                            }
                        break;
                    case 6:
                        Console.WriteLine("Выполнение шестой задачи");
                        Task6();
                        break;
                    case 7:
                        Console.Write("\n7а - 1; \n7б - 2; " +
                            "\nВыберите подпункт седьмой задачи: ");
                        int sevenTaskNumber = int.Parse(Console.ReadLine());
                        switch (sevenTaskNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение пункта А седьмой задачи. ");
                                Task7A();
                                break;
                            case 2:
                                Console.WriteLine("Выполнение пункта Б седьмой задачи. ");
                                Task7B();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
                        break;
                    case 0 :
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
