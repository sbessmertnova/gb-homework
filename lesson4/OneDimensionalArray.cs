using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    class OneDimensionalArray
    {
        private int[] array;
        public int [] Array { get; set;}

        public int GetElement(int index)
        {
            return array[index];
        }

        public int this [int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        public int Sum
        {
            get
            {
                var count = 0;
                foreach (var element in Array)
                {
                    count += element;
                }
                return count;
            }
        }
        public OneDimensionalArray (int amount, int inicialValue, int step)
        {
            var array = new int[amount];
            array[0] = inicialValue;
            for (int i = 1; i < amount; i++)
            {
                array[i] = inicialValue + step;
                inicialValue = array[i];
            }
            Array = array;
        }
        /// <summary>
        /// изменение знаков у всех элементов
        /// </summary>
        /// <returns></returns>
        public int [] Inverse ()
        {
            var newArray = new int[Array.Length];
            for (int i = 0; i < Array.Length; i++)
            {
                int element = Array[i];
                newArray[i] = -element;
            }
            return newArray;
        }
        /// <summary>
        /// умножение каждого элемента на определенное число
        /// </summary>
        /// <param name="number">число, на которое необходимо умножить</param>
        /// <returns></returns>
        public void Multi (int number)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = Array[i] * number;
            }
        }
        /// <summary>
        /// нахождение количества максимальных чисел
        /// </summary>
        /// <param name="array">массив из чисел</param>
        /// <returns></returns>
        public int MaxCount(int[] array)
        {
            var count = 0;
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }
            foreach (var number in array)
            {
                if (number == max) count++;
            }
            return count;
        }
        /// <summary>
        /// вывод элементов массива в консоль
        /// </summary>
        /// <param name="array">массив для вывода</param>
        public void PrintArray(OneDimensionalArray array)
        {
            for (int i = 0; i < array.Array.Length; i++)
            {
                Console.Write($"{array.Array[i]}\t");
            }
        }
    }

}
