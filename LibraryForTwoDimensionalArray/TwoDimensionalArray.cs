using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTwoDimensionalArray
{
    public class TwoDimensionalArray
    {
        private int[,] array;
        public int[,] Array { get; set; }
        Random random = new Random();
        public TwoDimensionalArray (int firstDimention, int secondDimention)
        {
            var array = new int[firstDimention, secondDimention];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-100, 101);
                }
            }
            Array = array;
        }
        public int Sum()
        {
            var secondDimention = Array.GetLength(1);
            var firstDimention = Array.GetLength(0);
            var count = 0;
            for (int i = 0; i < firstDimention; i++)
            {
                for (int j = 0; j < secondDimention; j++)
                {
                    count += Array[i,j];
                }
            }
            return count;
        }
        public int SumMoreThanGiven(int given)
        {
            var secondDimention = Array.GetLength(1);
            var firstDimention = Array.GetLength(0);
            var count = 0;
            for (int i = 0; i < firstDimention; i++)
            {
                for (int j = 0; j < secondDimention; j++)
                { 
                    if(Array[i, j] > given)
                    {
                        count += Array[i, j];
                    }
                }
            }
            return count;
        }

    }
}
