using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Packages
{
    public static class SumOfArray
    {
        public static int SequentialSumOfArray(int[] list, int low, int high)
        {
            if (low >= high)
            {
                return list[low];
            }
            else
            {
                int mid = low + ((high - low) / 2);

                return (SequentialSumOfArray(list, low, mid) + SequentialSumOfArray(list, mid + 1, high));
            }
        }

        public static int ParallelSumOfArray(int[] list, int low, int high, int cores)
        {
            if ( low >= high )
            {
                return list[low];
            }
            else
            {
                int mid = low + ((high - low) / 2);
                int s1 = 0, s2 = 0;

                if (cores > 0)
                {
                    Parallel.Invoke(
                        () => { s1 = ParallelSumOfArray(list, low, mid, cores-2); },
                        () => { s2 = ParallelSumOfArray(list, mid + 1, high, cores - 2); }
                    );
                    return (s1 + s2);
                }
                else
                {
                    return (SequentialSumOfArray(list, low, mid) + SequentialSumOfArray(list, mid + 1, high));
                }                
            }
        }
    }

}
