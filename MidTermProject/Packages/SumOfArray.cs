using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Packages
{
    public class SumOfArray1
    {
        public int[] Input { set; get; }
        private int[] _tmpArray;
        private int _j; // Loop index
        private bool _flag = false;
        public int[] Output
        {
            get
            {
                if (_flag)
                {
                    _tmpArray[0] = Input[0];
                    return _tmpArray;
                }
                else
                {
                    return Input; // Input array now contains result (prefix sum)
                }
            }
        }

        public void ParalleledSumOfArray()
        {
            int n;

            n = Input.Length;
            _tmpArray = new int[n];

            for (_j = 0; _j <= (int)Math.Ceiling(Math.Log(n, 2)) - 1; _j++)
            {
                _flag = !_flag;
                if (_flag)
                {
                    for (int i = 0; i <= (int)Math.Pow(2, _j) - 1; i++)
                    {
                        _tmpArray[i] = Input[i];
                    }
                }
                else
                {
                    for (int i = 0; i <= (int)Math.Pow(2, _j) - 1; i++)
                    {
                        Input[i] = _tmpArray[i];
                    }

                }
                System.Threading.Tasks.Parallel.For((int)Math.Pow(2, _j) + 1, n + 1, ForBody);
            }
        }

        private void ForBody(int i)
        {
            if (_flag)
                _tmpArray[i - 1] = Input[i - 1] + Input[i - (int)Math.Pow(2, _j) - 1];
            else
                Input[i - 1] = _tmpArray[i - 1] + _tmpArray[i - (int)Math.Pow(2, _j) - 1];
        }

        public int SequentialSumOfArray(int[] list)
        {
            return list.Sum();
        }
    }

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
