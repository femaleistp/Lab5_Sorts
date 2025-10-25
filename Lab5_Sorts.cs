using System;
using System.Linq;
using System.Diagnostics;
using System.Globalization;

namespace Lab5_Sorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab 5: Sorting Algorithmsin Action ===\n");

            int[] numbers = { 38, 27, 43, 3, 9 };
            Console.WriteLine("Original array: [" + string.Join(", ", numbers) + "]");

            BubbleSort(numbers);

            Console.WriteLine("Sorted array: [" + string.Join(", ", numbers) + "]\n");
          
        }

        // This method implements the Bubble Sort algorithm to sort an array of integers in ascending order.
        /// <summary>
        /// Bubble Sort Algorithm
        /// </summary>
        /// <param name="arr">Array of integers to be sorted</param>
        /// <remarks>Complexity time O(n^2) and space O(1)</remarks>
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

    }
}