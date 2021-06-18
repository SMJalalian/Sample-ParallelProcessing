using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Packages
{
    public static class Tools
    {
        public static double[,] GenerateRandomMatrix (int row, int col)
        {
            Random random = new Random();

            double[,] array = new double[row, col];

            for (int i = 0; i < row; ++i)
                for (int j = 0; j < col; ++j)
                    array[i, j] = random.Next(-100,100); // NextDouble already returns double from [0,1)
            return array;
        }

        public static int[] GenerateRandomList(int number)
        {
            Random random = new Random();

            int[] list = new int[number];

            for (int i = 0; i < number; i++)
                list[i] = random.Next(1 , 10); // NextDouble already returns double from [0,1)
            return list;
        }

        public static void SwapArrayElement(int[] inputArray, int i, int j)
        {
            // Swap two element in an array with given indexes.
            int temp = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = temp;

        }
    }
}
