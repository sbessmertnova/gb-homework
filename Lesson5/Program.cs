using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lesson5
{
    class Program
    {
        //Бессмертнова
        #region Задача№1- a
        /// <summary>
        /// 1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов,
        /// содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        /// а) без использования регулярных выражений;
        /// </summary>
        /// 
        static void Task1A()
        {
            Console.Write("Логин должен содержать от 2 до 20 символов (буквы латинского алфавита или цифры. Цифра не должны быть первой. \nВведите логин:");
            var userInput = Console.ReadLine();
            if (userInput.Length >= 2 && userInput.Length <= 10 && IsLatinLetter(userInput[0]))
            {
                bool valid = true;

                for (int i = 0; i < userInput.Length && valid; i++)
                {
                    valid = IsLatinLetter(userInput[i]) || char.IsNumber(userInput[i]);
                    if (valid != false)
                    {
                        continue;
                    }
                    Console.WriteLine("Некорректный логин");
                    return;
                }
                Console.WriteLine("Добро пожаловать!");
            }
            else
            {
                Console.WriteLine("Некорректный логин");
            }
            Console.ReadKey();
        }
        public static bool IsLatinLetter(char latter)
        {
            return (latter >= 'a' && latter <= 'z') || (latter >= 'A' && latter <= 'Z');
        }
        #endregion
        #region Задача№1-б
        /// <summary>
        /// б) **с использованием регулярных выражений.
        /// </summary>
        static void Task1B()
        {
            Console.Write("Логин должен содержать от 2 до 20 символов (буквы латинского алфавита или цифры. Цифра не должны быть первой. \nВведите логин:");
            var userInput = Console.ReadLine();

            Regex regexQuantifier = new("^[a-zA-Z]{1,1}[a-zA-Z0-9]{2,20}$");

            if (regexQuantifier.IsMatch(userInput))
            {
                Console.WriteLine("Добро пожаловать!");

            }
            else
            {
                Console.WriteLine("Некорректный логин");
            }
            Console.ReadKey();

        }
        #endregion
        #region Задача№2
        /// <summary>
        /// Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        /// а) Вывести только те слова сообщения, которые содержат не более n букв.
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// в) Найти самое длинное слово сообщения.
        /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// </summary>
        static void Task2()
        {
            var userMessage = "Захар Павлович молчал: человеческое слово для него что лесной шум для жителя леса– его не слышишь. " +
                "Сторож курил и спокойно глядел дальше– в Бога он от частых богослужений не верил, но знал наверное, " +
                "что ничего у Захара Павловича не выйдет: люди давно на свете живут и уже все выдумали. А Захар Павлович считал наоборот:" +
                " люди выдумали далеко не все, раз природное вещество живет нетронутое руками.";
            Message.PrintWords(userMessage, 4);
            Console.WriteLine();
            Message.DeleteWords(userMessage, 'л');
            Console.WriteLine();
            Console.WriteLine($"Самые(-ое) длинные(-ое) слова(-о), способ №1 (длинный): {string.Join(',', Message.FindLongestWords(userMessage))}");
            Console.WriteLine();
            Console.WriteLine($"Самые(-ое) длинные(-ое) слова(-о), способ №2 (короткий): {string.Join(',', Message.FindLongestWordsShort(userMessage))}");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Задача№3
        /// <summary>
        ///*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        ///Например: badc являются перестановкой abcd.
        /// </summary>
        static void Task3()
        {
            const string testString = "alert";
            const string validAnagram = "alter";
            const string invalidAnagram = "after";

            Console.WriteLine("Использование метода IsAnagram: ");
            if (IsAnagram(testString, validAnagram))
                Console.WriteLine($"Строки {testString} {validAnagram} являются анаграммой.");
            else
                Console.WriteLine($"Строки {testString} {validAnagram} не являются анаграммой.");
            if (IsAnagram(testString, invalidAnagram))
                Console.WriteLine($"Строки {testString} {invalidAnagram} являются анаграммой.");
            else
                Console.WriteLine($"Строки {testString} {invalidAnagram} не являются анаграммой.");

            Console.WriteLine("Использование более короткого метода IsAnagramShort: ");
            if (IsAnagramShort(testString, validAnagram))
                Console.WriteLine($"Строки {testString} {validAnagram} являются анаграммой.");
            else
                Console.WriteLine($"Строки {testString} {validAnagram} не являются анаграммой.");
            if (IsAnagramShort(testString, invalidAnagram))
                Console.WriteLine($"Строки {testString} {invalidAnagram} являются анаграммой.");
            else
                Console.WriteLine($"Строки {testString} {invalidAnagram} не являются анаграммой.");

            Console.ReadKey();
        }
        /// <summary>
        /// проверяет, является ли первая строка анаграммой второй
        /// </summary>
        /// <param name="firstString">первая строка</param>
        /// <param name="secondString">вторая строка</param>
        /// <returns></returns>
        public static bool IsAnagram(string firstString, string secondString)
        {
            if (firstString.Length == secondString.Length && SecondContains(firstString, secondString))
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    char letterFromFirstString = secondString[i];
                    if (!firstString.Contains(letterFromFirstString))
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// отвечает на вопрос, содержит ли вторая строка все символы первой
        /// </summary>
        /// <param name="firstString">первая строка</param>
        /// <param name="secondString">вторая строка</param>
        /// <returns></returns>
        public static bool SecondContains(string firstString, string secondString)
        {
            for (int i = 0; i < firstString.Length; i++)
            {
                char letterFromSecondString = firstString[i];
                if (!secondString.Contains(letterFromSecondString))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Упрощенный метод проверки, является ли первая строка анаграммой второй
        /// </summary>
        /// <param name="firstString">первая строка</param>
        /// <param name="secondString">вторая строка</param>
        /// <returns></returns>
        public static bool IsAnagramShort(string firstString, string secondString)
        {
            var sortedTestString = firstString.OrderBy(letter => letter);
            var sortedValidAnagram = secondString.OrderBy(letter => letter);
            return sortedTestString.SequenceEqual(sortedValidAnagram);
        }
        #endregion
        #region Задача№4
        /// <summary>
        ///На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, 
        ///которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:<Фамилия> <Имя> <оценки>,
        ///где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, 
        ///соответствующие оценкам по пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:Иванов Петр 4 5 3
        ///Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
        ///Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
        /// </summary>
        static void Task4()
        {
            var input = new string[]
            {
                "10",
                "Иванов Петр 4 5 3",
                "Петров Иван 4 5 3",
                "Петров Александр 3 4 3",
                "Волков Михаил 5 5 2",
                "Зайцева Наталья 4 2 3",
                "Лисовая Валерия 5 4 5",
                "Котин Вячеслав 1 3 5",
                "Сорова Анна 4 4 5",
                "Романов Виктор 3 3 2",
                "Николаева Катерина 5 3 5"
            };
            if (CheckNumberOfStudent(input))
            {
                var students = new List<Student>();
                for (int i = 1; i < input.Length; i++)
                {
                    Student student = new Student(input[i]);
                    students.Add(student);
                }
                var grouped = students.GroupBy(student => student.MiddleMark);
                var sortedMiddleMarks = grouped.OrderBy(studentGroup => studentGroup.Key);

                var firstWorstStudents = sortedMiddleMarks.First().ToList();
                var secondWorstStudents = sortedMiddleMarks.Skip(1).First().ToList();
                var thirdWorstStudents = sortedMiddleMarks.Skip(2).First().ToList();

                Console.WriteLine($"Первое место с конца: {string.Join(',', firstWorstStudents)}, " +
                    $"\nВторое место с конца: {string.Join(',', secondWorstStudents)}, " +
                    $"\nТретье место с конца: {string.Join(',', thirdWorstStudents)}");
            }
            Console.ReadKey();
        }           
        public static bool CheckNumberOfStudent(string[] input)
        {
            var number = int.Parse(input[0]);
            return number >= 10 && number <= 100;
        }
        #endregion

        static void Main(string[] args)
        {
            bool f = true;
            while (f)
            {
                Console.Write("Задача №1 - 1;  \nЗадача №2 - 2; \nЗадача №3 - 3; \nЗадача №4 - 4;" +
                    "\nРешение какой задачи запустить? Введите соответствующее число: ");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        Console.WriteLine("Выберите подпункт первой задачи \nA - нажмите 1; \nБ - нажмите 2;" +
                            "\nРешение какой задачи запустить? Введите соответствующее число: ");
                        var userNumber = int.Parse(Console.ReadLine());
                        switch (userNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение пункста А первой задачи. ");
                                Task1A();
                                break;
                            case 2:
                                Console.WriteLine("Выполнение пункстов Б первой задачи. ");
                                Task1B();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
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
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Выполнение четвертой задачи. ");
                        Task4();
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


    

