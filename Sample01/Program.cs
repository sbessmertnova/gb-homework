using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Бессмертнова

            #region Задание №1
            //Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
            //а) используя склеивание;
            //б) используя форматированный вывод;
            //в) используя вывод со знаком $.

            Console.WriteLine("Ваше имя?");
            string name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ваша фамилия?");
            string surName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ваш возраст?");
            double age = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Ваш рост?");
            double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Ваш вес?");
            double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Имя: " + name + ", " + "фамилия: " + surName + ", " + "возраст: " + age + ", " + "рост: " + height + ", " + "вес: " + weight);
            Console.WriteLine("Имя: {0}, фамилия: {1}, возраст: {2}, рост: {3}, вес: {4}", name, surName, age, height, weight);
            Console.WriteLine($"Имя: {name}, фамилия: {surName}, возраст: {age}, рост: {height}, вес: {weight}");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №2
            //Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
            var bmi = HelperMethods.CalculateBodyMassIndex();
            Console.WriteLine($"Индекс массы тела: {bmi:F2}");
            Console.ReadLine();
            Console.Clear();

            #endregion

            #region Задание №3-A
            //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);

            double x1 = -2.3;
            double y1 = 4;
            double x2 = 8.5;
            double y2 = 0.7;
            var r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Расстояние между точками с координатами x1, y1 и x2, y2 : {r:F2}");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №3-Б
            //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.


            void CalculateDistance(double firstX, double firstY, double secondX, double secondY)
            {
                var distance = Math.Sqrt(Math.Pow(secondX - firstX, 2) + Math.Pow(secondY - firstY, 2));
                Console.WriteLine($"Расстояние между точками с координатами x1, y1 и x2, y2 : {distance:F2}");
            }

            CalculateDistance(-2.3, 4, 8.5, 0.7);

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №4-A
            //Написать программу обмена значениями двух переменных:
            //а) с использованием третьей переменной;

            int x = 1;
            int y = 2;
            int z = x;
            x = y;
            y = z;
            Console.WriteLine($"x = {x}, y = {y}");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №4-Б
            //б) *без использования третьей переменной.

            var a = 1;
            var b = 2;

            a += b; // a = сумма
            b = a - b; // b = a изначальная
            a -= b; // а = сумма - a изначальная, т.е. b

            Console.WriteLine($"a = {a}, b = {b}");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №5-А
            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            
            Console.WriteLine("Светлана Бессмертнова, Санкт-Петербург");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №5-Б
            //б) *Сделать задание, только вывод организовать в центре экрана.

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Светлана Бессмертнова, Санкт-Петербург");

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №5-В
            //в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).

            void Print(string output, int left, int top)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(output);

            }

            Print("Светлана Бессмертнова, Санкт-Петербург", 65, 23);

            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Задание №6
            //Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).

            // класс NecessaryMethods в HelperMethods.cs
            #endregion
        }
    }
}


