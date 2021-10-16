using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class ComplexClass
    {
        public double im;
        public double re;
        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="subtrahend"></param>
        /// <returns></returns>
        public static ComplexClass Subtract(ComplexClass minuend, ComplexClass subtrahend)
        {
            return new ComplexClass(minuend.re - subtrahend.re, minuend.im - subtrahend.im);
        }
        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static ComplexClass Multi(ComplexClass multiplier, ComplexClass multiplicand)
        {
            return new ComplexClass (multiplicand.re * multiplier.re - multiplicand.im * multiplier.im,
                multiplicand.re * multiplier.im + multiplicand.im * multiplier.re);
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
}
