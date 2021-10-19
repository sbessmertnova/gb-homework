using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    struct Account
    {
        public string login;
        public string password;
    }

    class Program
    {
        //Бессмертнова
        #region Задание №1
        /// <summary>
        /// Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения 
        /// от –10 000 до 10 000 включительно. Заполнить случайными числами. Написать программу, 
        /// позволяющую найти и вывести количество пар элементов массива, в которых только одно 
        /// число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента 
        /// массива.
        /// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
        /// </summary>
        static void Task1()
        {
            var numbers = new int[20];
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-10000, 10001);
            }
            var amount = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (DivideByThree(numbers[i], numbers[i + 1]))
                {
                    amount++;
                }
            }
            Console.WriteLine($"Количество пар элементов, в которых только одно число делится на три: {amount}");
        }
        /// <summary>
        /// Метод, отвечающий на вопрос: делится ли одно из двух чисел на 3
        /// </summary>
        /// <param name="firstNumber">первое число</param>
        /// <param name="secondNumber">второе число</param>
        /// <returns></returns>
        static bool DivideByThree (int firstNumber, int secondNumber)
        {
            return ((firstNumber %3==0 || secondNumber%3==0) && !(firstNumber % 3 == 0 && secondNumber % 3 == 0));
        }
        #endregion
        #region Задание №2-a
        /// <summary>2. Реализуйте задачу 1 в виде статического класса StaticClass;
        /// а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        static void Task2A()
        {
            var numbers = new int[20];
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-10000, 10001);
            }
            StaticClass.PrintAmountOfSpecialPairs(numbers);
        }
        #endregion
        #region Задание №2-б и в
        /// <summary>2. Реализуйте задачу 1 в виде статического класса StaticClass;
        /// б) Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        /// в)*Добавьте обработку ситуации отсутствия файла на диске.
        static void Task2B()
        {
            var array = StaticClass.LoadArrayFromFile("C:\\Users\\minni\\source\\lesson1\\Lesson1\\lesson4\\bin\\Debug\\MyArray.txt");
            StaticClass.PrintArray(array);
            Console.ReadKey();
        }
        #endregion

        #region Задание №3-a
        /// <summary>а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив 
        /// определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
        /// Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив 
        /// с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, 
        /// умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных 
        /// элементов.
        static void Task3A()
        {
            var array = new OneDimensionalArray(25, 5, 2);
            Console.Write("Элементы массива: ");
            array.PrintArray(array);
            Console.WriteLine($"\nСумма элементов массива: {array.Sum}");
            Console.WriteLine($"Массив с измененными значениями: ");
            StaticClass.PrintArray(array.Inverse());
            Console.WriteLine("\nДемонстрация метода Multi: ");
            array.Multi(2);
            array.PrintArray(array);
            array.Array[array.Array.Length-2] = array.Array[array.Array.Length - 1];//делаем предпоследний элемент равным последнему(максимальному)
            Console.WriteLine("\nДемонстрация метода MaxCount:");
            Console.WriteLine($"\nКоличество максимальных элементов в массиве: {array.MaxCount(array.Array)}");
            Console.WriteLine("\nМассив:");
            array.PrintArray(array);
            Console.ReadKey();

        }
        #endregion
        #region Задание №3-б
        /// б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
        static void Task3B()
        {
            var arrayFromLibrary = new LibraryForLesson4.OneDimensionalArray(10, 10, 1);
            Console.Write("Демонстрация работы библиотеки. \nЭлементы массива: ");
            arrayFromLibrary.PrintArray(arrayFromLibrary);
            Console.ReadKey();
        }
        #endregion
        #region Задание №3-в
        /// в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
        static void Task3C()
        {
            int[] array = { 3, 1, 5, 3, -12, 5, 34, 2, 5, 7 };
            var dictionary = new Dictionary<int, int> { };
            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    dictionary[array[i]] += 1;
                }
                else
                {
                    dictionary.Add(array[i], 1);
                }
            }
            Console.WriteLine("Частота вхождения элементов в массив: ");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"\n{item.Key} - { item.Value}");
            }
            Console.ReadKey();
        }
        #endregion
        #region Задание №4
        /// Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
        /// <summary>
        /// загрузка массива элементов из файла
        /// </summary>
        /// <param name="PathToFile">путь к файлу</param>
        /// <returns></returns>
        public static Account[] LoadAccountsFromFile(string PathToFile)
        {
            if (!File.Exists(PathToFile))
            {
                return null;
            }
            var contents = File.ReadAllLines(PathToFile);
            Account[] result = new Account[contents.Length];
            for (int i = 0; i < contents.Length; i++)
            {
                string contentLine = contents[i];
                var elementAccount = contentLine.Split(' ');
                result[i] = new Account { login = elementAccount[0], password = elementAccount[1] };
            }
            return result;
        }
        /// <summary>
        /// сравнивает строки с корректными логином и паролем
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        public static bool CheckLoginAndPassword(string login, string password)
        {
            return login == "root" && password == "GeekBrains";
        }

        static void Task4()
        {
                int tryCounter = 0;
                int maxTry = 3;
                bool valid;
                var accounds = LoadAccountsFromFile("C:\\Users\\minni\\source\\lesson1\\Lesson1\\lesson4\\bin\\Debug\\LoginAndPassword.txt");
            for (int i = 0; i < accounds.Length; i++)
            {
                valid = CheckLoginAndPassword(accounds[i].login, accounds[i].password);
                tryCounter += 1;
                if (valid)
                {
                    Console.WriteLine("Вы ввели верные креды. Добро пожаловать!");
                }
                else if (tryCounter < maxTry)
                {
                    Console.WriteLine($"Логин и/или пароль неверные. Попробуйте снова. Попыток осталось: {(maxTry - tryCounter)}");
                }
                else
                {
                    Console.WriteLine("Вы исчерпали 3 попытки. Вход невозможен.");
                    return;
                }
            }
        }
        #endregion
        #region Задание №5
        /// а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, 
        /// которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
        /// возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
        /// *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// ** в) Обработать возможные исключительные ситуации при работе с файлами.
        static void Task5()
        {
            var array = new LibraryForTwoDimensionalArray.TwoDimensionalArray(4, 5);
            var sum = array.Sum();
            Console.WriteLine($"Сумма элементов двумерного массива: {sum}");
            Console.WriteLine($"Сумма элементов двумерного массива, больше заданного: {array.SumMoreThanGiven(40)}");
        }
        #endregion
        static void Main(string[] args)
        {
            bool f = true;
            while (f)
            {
                Console.Write("Задача №1 - 1;  \nЗадача №2 - 2; \nЗадача №3 - 3; \nЗадача №4 - 4; \nЗадача №5 - 5;" +
                    "\nРешение какой задачи запустить? Введите соответствующее число: ");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        Console.WriteLine("Выполнение первой задачи. ");
                        Task1(); 
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выберите подпункт второй задачи \nA - нажмите 1; \nБ и В - нажмите 2;" +
                            "\nРешение какой задачи запустить? Введите соответствующее число: ");
                        var userNumber = int.Parse(Console.ReadLine());
                        switch (userNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение пункста А второй задачи. ");
                                Task2A();
                                break;
                            case 2:
                                Console.WriteLine("Выполнение пункстов Б и В второй задачи. ");
                                Task2B();
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Выберите подпункт третьей задачи \nA - нажмите 1; \nБ - нажмите 2; \nB - нажмите 3;" +
                        "\nРешение какой задачи запустить? Введите соответствующее число: ");
                        userNumber = int.Parse(Console.ReadLine());
                        switch (userNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение пункста А третьей задачи. ");
                                Console.Clear();
                                Task3A();
                                break;
                            case 2:
                                Console.WriteLine("Выполнение пункста Б третьей задачи. ");
                                Console.Clear();
                                Task3B();
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Выполнение пункста В третьей задачи. ");
                                Console.Clear();
                                Task3C();
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Выполнение четвертой задачи. ");
                        Task4();
                        break;
                    case 5:
                        Console.WriteLine("Выполнение пятой задачи. ");
                        Task5();
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
