using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    static class StaticClass
    {
        /// <summary>
        /// Метод выводит на экран количество пар элементов
        /// </summary>
        /// <param name="array">массив с элементами</param>
        public static void PrintAmountOfSpecialPairs(int[] array)
        {
            var amount = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (DivideByThree(array[i], array[i + 1]))
                {
                    amount++;
                }
            }
            Console.WriteLine($"Количество пар элементов, в которых только одно число делится на три: {amount}");
        }
        /// <summary>
        /// Метод, отвечающий на вопрос, делится ли однно число из пары чисел на 3
        /// </summary>
        /// <param name="firstNumber">первое число</param>
        /// <param name="secondNumber">второе число</param>
        /// <returns></returns>
        static bool DivideByThree(int firstNumber, int secondNumber)
        {
            return ((firstNumber % 3 == 0 || secondNumber % 3 == 0) && !(firstNumber % 3 == 0 && secondNumber % 3 == 0));
        }
        /// <summary>
        /// загрузка массива элементов из файла
        /// </summary>
        /// <param name="PathToFile">путь к файлу</param>
        /// <returns></returns>
        public static int[] LoadArrayFromFile(string PathToFile)
        {
            if (!File.Exists(PathToFile))
            {
                return null;
            }
            StreamReader reader = new StreamReader(PathToFile);
            int[] array = new int[1000];
            var counter = 0;
            while (!reader.EndOfStream)
            {
                array[counter] = int.Parse(reader.ReadLine());
                counter++;
            }
            reader.Close();
            int[] newArray = new int[counter];
            Array.Copy(array, newArray, counter);
            return newArray;
        }
        /// <summary>
        /// вывод элементов массива в консоль
        /// </summary>
        /// <param name="array">массив для вывода</param>
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }
    }
}
