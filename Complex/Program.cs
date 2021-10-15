using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
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
        public static Complex Subtract(Complex subtrahend, Complex minuend)
        {
            Complex difference;
            difference.im = minuend.im - subtrahend.im;
            difference.re = minuend.re - subtrahend.re;
            return difference;
        }
        /// <summary>
        /// Умножение комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        /// <summary>
        /// Вывод результата арифметических вычислений с комплексными числами
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (im > 0) ? $"{re} + {im}i" : $"{re} - {-im}i";
        }

        class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
