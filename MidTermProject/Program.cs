using MidTermProject.Packages;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MidTermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int cpuCores = 8;
            while (true)
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    int choise = 0;
                    bool flag = true;
                    while (flag)
                    {
                        Console.Write("What question do you want to solve ? \n" +
                            "1- Matrix Multiplication \n" +
                            "2- Bubble Sort \n" +
                            "3- Sum of Array  \n" +
                            "Please Enter Your Choise: (1-3): ");

                        ConsoleKeyInfo inputKey = Console.ReadKey();

                        choise = Convert.ToInt32(inputKey.KeyChar.ToString());
                        if (Enumerable.Range(1, 3).Contains(choise))
                            flag = false;
                        else
                        {
                            Console.Write("\nYou choose wrong number, Please retry .... !!!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }

                    Console.WriteLine("\n*************************************************\n");
                    switch (choise)
                    {
                        case 1:
                            #region Matrix Multiplication

                            Console.Write("Please enter size of Matrix-A rows: ");
                            int rowA = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter size of Matrix-A cols: ");
                            int colA_rowB = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter size of Matrix-B Cols: ");
                            int colB = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Matrix Multiplication, Plase wait for result ... ");
                            double[,] matrixA = Packages.Tools.GenerateRandomMatrix(rowA, colA_rowB);
                            double[,] matrixB = Packages.Tools.GenerateRandomMatrix(colA_rowB, colB);

                            Console.WriteLine("\nSequential Process is Starting ... "); 
                            sw.Start();
                            MatrixMultiplication.SequentialMultiplication(matrixA, matrixB);
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);
                            Console.WriteLine("\n#########################\n");

                            sw.Reset();

                            Console.WriteLine("Parallel Process is Starting ... ");
                            sw.Start();
                            MatrixMultiplication.ParalleledMultiplication(matrixA, matrixB);
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);

                            break;
                        #endregion
                        case 2:
                            #region Bubble Sort
                            Console.Write("Pleas enter your desired size of array: ");
                            int arrayLength = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("BubbleSort, Plase wait for result ... ");

                            int[] myList1 = new int[arrayLength];
                            int[] myList2 = new int[arrayLength];
                            int[] randomList = Packages.Tools.GenerateRandomList(arrayLength);
                            randomList.CopyTo(myList1, 0);
                            randomList.CopyTo(myList2, 0);

                            Console.WriteLine("\nSequential Process is Starting ... ");
                            sw.Start();
                            Packages.BubbleSort.SequentialBubbleSort(myList1);
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);
                            Console.WriteLine("\n#########################\n");

                            sw.Reset();

                            Console.WriteLine("Parallel Process is Starting ... ");
                            sw.Start();
                            Packages.BubbleSort.ParallelBubbleSort(myList2);
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);

                            break;
                        #endregion
                        case 3:
                            #region Sum Of Array
                            Console.Write("Pleas enter your desired size of array: ");
                            arrayLength = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Sum of array, Plase wait for result ... ", arrayLength);
                            
                            randomList = Tools.GenerateRandomList(arrayLength);

                            Console.WriteLine("\nSequential Process is Starting ... ");
                            sw.Start();
                            Console.WriteLine("Result is : " + SumOfArray.SequentialSumOfArray(randomList, 0, arrayLength - 1));
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);
                            Console.WriteLine("\n#########################\n");

                            sw.Reset();

                            Console.WriteLine("Parallel Process is Starting ... ");
                            sw.Start();
                            Console.WriteLine("Result is : " + SumOfArray.ParallelSumOfArray(randomList, 0, arrayLength - 1, cpuCores));
                            sw.Stop();
                            Console.WriteLine("Time elapsed: " + sw.Elapsed);

                            break;
                        #endregion
                        default:
                            break;
                    }
                    Console.WriteLine("\n*************************************************\n");
                    
                    Console.Write("Please enter ( n/N ) to quit .... ");
                    var key = Console.ReadKey();
                    if (key.KeyChar.ToString().ToLower() == "n")
                        Environment.Exit(0);
                    else
                        Console.Clear();
                }
                catch (Exception)
                {
                    Console.Write("\nYou choose wrong input, Please retry .... !!!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
