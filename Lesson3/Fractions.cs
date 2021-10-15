using System;

namespace Lesson3
{
    class Fractions
    {
        private int _denominator;
        private int _numerator;

        public int Denominator
        {
            get => _denominator;
            set
            {
                if (_denominator == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                _denominator = value;
            }
        }
        public int Numerator { get => _numerator; set => _numerator = value; }
        public double Quotient => (Convert.ToDouble(_numerator) / Convert.ToDouble(_denominator));

        public Fractions(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            Numerator = numerator;
            _denominator = denominator;
        }

        /// <summary>
        /// Вычитание дробей
        /// </summary>
        /// <param name="minuend">уменьшаемое</param>
        /// <param name="subtrahend">вычитаемое</param>
        /// <returns></returns>
        public static Fractions SubtractFractions(Fractions minuend, Fractions subtrahend)
        {
            int generalDenominator = CommonDenominator(minuend, subtrahend, out int minuendNumerator, out int subtrahendNumeratur);

            return Reduce(new Fractions(minuendNumerator - subtrahendNumeratur, generalDenominator));

        }
        /// <summary>
        /// Сложение дробей
        /// </summary>
        /// <param name="firstTerm">перваое слагаемое</param>
        /// <param name="subtrahend">второе слагаемое</param>
        /// <returns></returns>
        public static Fractions AddFractions(Fractions firstTerm, Fractions secondTerm)
        {
            int generalDenominator = CommonDenominator(firstTerm, secondTerm, out int numeratorOfFirstFraction, out int numeraturOfSecondFraction);
            return Reduce(new Fractions(numeratorOfFirstFraction + numeraturOfSecondFraction, generalDenominator));
        }
        /// <summary>
        /// Умножение дробей
        /// </summary>
        /// <param name="firstFactor">первый множитель</param>
        /// <param name="secondFactor">второй множитель</param>
        /// <returns></returns>
        public static Fractions MultiplyFractions(Fractions firstFactor, Fractions secondFactor)
        {
            int generalNumerator = firstFactor.Numerator * secondFactor.Numerator;
            int generalDenominator = firstFactor._denominator * secondFactor._denominator;
            return Reduce(new Fractions(generalNumerator, generalDenominator));
        }
        /// <summary>
        /// Деление дробей
        /// </summary>
        /// <param name="dividend">делимое</param>
        /// <param name="divider">делитель</param>
        /// <returns></returns>
        public static Fractions DivideFractions(Fractions dividend, Fractions divider)
        {
            int generalNumerator = dividend.Numerator * divider._denominator;
            int generalDenominator = dividend._denominator * divider.Numerator;
            return Reduce(new Fractions(generalNumerator, generalDenominator));
        }
        /// <summary>
        /// Приведение дробей к общему знаменателю
        /// </summary>
        /// <param name="firstFraction">первая дробь</param>
        /// <param name="secondFraction">вторая дробь</param>
        /// <param name="numeratorOfFirstFraction">числитель первой дроби, умноженный на знаменатель второй</param>
        /// <param name="numeraturOfSecondFraction">числитель второй дроби, умноженный на знаменатель первой/param>
        /// <returns></returns>
        static int CommonDenominator(Fractions firstFraction, Fractions secondFraction, out int numeratorOfFirstFraction, out int numeraturOfSecondFraction)
        {
            numeratorOfFirstFraction = firstFraction.Numerator * secondFraction._denominator;
            numeraturOfSecondFraction = secondFraction.Numerator * firstFraction._denominator;
            int generalDenominator = firstFraction._denominator * secondFraction._denominator;
            return generalDenominator;
        }
        /// <summary>
        /// Упрощение дроби
        /// </summary>
        /// <param name="fraction">дробь, которую необходимо упростить</param>
        /// <returns></returns>
        static Fractions Reduce(Fractions fraction)
        {
            int minCommonDivisor = GetBiggestDivisor(fraction.Numerator, fraction._denominator);
            return new Fractions(fraction.Numerator / minCommonDivisor, fraction._denominator / minCommonDivisor);
        }
        /// <summary>
        /// Нахождение наименьшего общего делителя
        /// </summary>
        /// <param name="firstValue">первое число</param>
        /// <param name="secondValue">второе число</param>
        /// <returns></returns>
        static int GetBiggestDivisor(int firstValue, int secondValue)
        {
            firstValue = Math.Abs(firstValue);
            secondValue = Math.Abs(secondValue);
            if (firstValue == secondValue)
            {
                return firstValue;
            }
            if (firstValue > secondValue)
            {
                int tempValue = firstValue;
                firstValue = secondValue;
                secondValue = tempValue;
            }
            return GetBiggestDivisor(firstValue, secondValue - firstValue);
        }
        /// <summary>
        /// Вывод результата арифметических вычислений с дробями
        /// </summary>
        public override string ToString()
        {
            return $"{_numerator}/{_denominator} ({Quotient:F2})";
        }
    }
}
