using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    //Бессмертнова 
    struct Complex
    {
        public double im;
        public double re;
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="subtrahend">вычитаемое комплексное число</param>
        /// <returns></returns>
        public Complex Subtract(Complex subtrahend)
        {
            Complex difference;
            difference.im = im - subtrahend.im;
            difference.re = re - subtrahend.re;
            return difference;
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        public static Complex Subtract(Complex minuend, Complex subtrahend)
        {
            Complex difference;
            difference.im = minuend.im - subtrahend.im;
            difference.re = minuend.re - subtrahend.re;
            return difference;
        }
        /// <summary>
        /// Вывод результата арифметических вычислений с комплексными числами
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (im > 0) ? $"{re} + {im}i" : $"{re} - {-im}i";
        }
    }

    class Program
    {
        #region Задание №1-a
        /// <summary>
        /// Задача 1 Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
        /// </summary>
        static void Task1A()
        {
            Complex complex1;
            complex1.re = 1;
            complex1.im = 1;

            Complex complex2;
            complex2.re = 3;
            complex2.im = 4;

            Complex result = complex1.Subtract(complex2);//использование нестатического метода
            Console.WriteLine($"Разность двух комплексных чисел {complex1} и {complex2} с использованием нестатического метода: " + result.ToString());
            result = Complex.Subtract(complex1, complex2); //использование статического метода
            Console.WriteLine($"Разность двух комплексных чисел {complex1} и {complex2} с использованием статического метода: " + result.ToString());
        }
        #endregion
        #region Задание №1-б и в
        /// <summary>
        /// Задача 1 б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
        /// в) Добавить диалог с использованием switch демонстрирующий работу класса.
        /// </summary>
        static void Task1B()
        {
            ComplexClass complex1 = new ComplexClass(1, 1);
            ComplexClass complex2 = new ComplexClass(3, 4);
            Console.Write("\nДемонстрация работы вычитания - 1; \nДемонстрация работы умножения - 2; " +
            "\nВыберите нужный номер: ");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine($"Разность двух комплексных чисел {complex1} и {complex2} с использованием метода класса: " + ComplexClass.Subtract(complex1, complex2).ToString());
                    break;
                case 2:
                    Console.WriteLine($"Произведение двух комплексных чисел {complex1} и {complex2} с использованием метода класса: " + ComplexClass.Multi(complex1, complex2).ToString());
                    break;
                default:
                    Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                    break;
            }
        }
        #endregion
        #region Задание №2
        /// <summary>
        /// Задача 2 С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
        /// Требуется подсчитать сумму всех нечётных положительных чисел. 
        /// Сами числа и сумму вывести на экран, используя tryParse.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Ввoдите числa. Для прекращения ввода введите .\"0.\" ");
            int number;
            int sum = 0;
            do
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number % 2 == 1)
                    {
                        sum += number;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                    return;
                }
            } while (number != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");
        }
        #endregion
        #region Задание №3
        /// <summary>
        /// Задача 3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
        /// Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
        /// * Добавить свойства типа int для доступа к числителю и знаменателю;
        /// * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
        /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
        /// *** Добавить упрощение дробей.
        /// </summary>
        static void Task3()
        {
            Fractions fraction1 = new Fractions(-5, 6);
            Fractions fraction2 = new Fractions(-2, 3);
            var subtractionResult = Fractions.SubtractFractions(fraction1, fraction2);
            Console.WriteLine("Разность двух дробей " + fraction1.ToString() + " и " + fraction2.ToString() + " равна " + subtractionResult.ToString());
            var additionResult = Fractions.AddFractions(fraction1, fraction2);
            Console.WriteLine("Сумма двух дробей " + fraction1.ToString() + " и " + fraction2.ToString() + " равна " + additionResult.ToString());
            var productResult = Fractions.MultiplyFractions(fraction1, fraction2);
            Console.WriteLine("Произведение двух дробей " + fraction1.ToString() + " и " + fraction2.ToString() + " равнo " + productResult.ToString());
            var divisionResult = Fractions.DivideFractions(fraction1, fraction2);
            Console.WriteLine("Частное двух дробей " + fraction1.ToString() + " и " + fraction2.ToString() + " равнo " + divisionResult.ToString());
        }
        #endregion

        static void Main(string[] args)
        {
            bool f = true;
            while (f)
            {
                Console.Write("Задача №1 - 1;  \nЗадача №2 - 2; \nЗадача №3 - 3;" +
                    "\nРешение какой задачи запустить? Введите соответствующее число: ");
                int taskNumber = int.Parse(Console.ReadLine());
                switch (taskNumber)
                {
                    case 1:
                        Console.Write("\n1а - 1; \n1б - 2; " +
                            "\nВыберите подпункт первой задачи: ");
                        int firstTaskNumber = int.Parse(Console.ReadLine());
                        switch (firstTaskNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение пункта А первой задачи. ");
                                Task1A();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выполнение пункта Б первой задачи. ");
                                Task1B();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выполнение второй задачи. ");
                        Task2();
                        break;
                    case 3:
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


    