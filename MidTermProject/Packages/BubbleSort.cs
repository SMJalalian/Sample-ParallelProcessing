using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Packages
{
    public static class BubbleSort
    {
        public static void SequentialBubbleSort(int[] list)
        {
            int n = list.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (list[j] > list[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
        }

        public static void ParallelBubbleSort(int[] list)
        {
            int n = list.Length;
            Parallel.For(0, n - 1, i =>
            {
                for (int j = 0; j < n - i - 1; j++)
                    if (list[j] > list[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
            });
        }
    }
}
