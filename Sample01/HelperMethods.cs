using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
    public class HelperMethods
    {
        public static void Print(string output, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(output);
        }

        public static void Pause(string output)
        {
            Console.WriteLine(output);
            Console.ReadKey();
        }

        public static double CalculateBodyMassIndex ()
        {
            Console.WriteLine("Ваш рост?(укажите в см)");
            var height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();

            Console.WriteLine("Ваш вес?(укажите в кг)");
            var weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Clear();
            return weight / (height / 100 * height / 100);
        }
        public static string DisplayText(double difference, bool countingDifference = true)
        {
            return countingDifference
                ? $" минимум на { difference:F1} кг"
                : "";
        }
        public static void EstimateBodyMassIndex(bool countingDifference = true)
        {
            double minNorm = 18.5;
            double maxNorm = 24.9;
            double bmi = HelperMethods.CalculateBodyMassIndex();
            if (bmi < minNorm)
            {
                var difference = minNorm - bmi;
                string output = DisplayText(difference, countingDifference);
                Console.WriteLine($"Недостаточный вес. Вам необходимо поправиться{output}.");
            }
            else if (bmi > maxNorm)
            {
                var difference = bmi - maxNorm;
                string output = DisplayText(difference, countingDifference);
                Console.WriteLine($"Избыточный вес. Вам необходимо похудеть{output}.");
            }
            else
            {
                Console.WriteLine($"У вас нормальный вес.");
            }
            Console.ReadKey();
            Console.Clear();

        }

    }
}
