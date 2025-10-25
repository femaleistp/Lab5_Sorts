/*
 * Lab 5: Sorting Algorithms in Action
 * Course: IT 415 — Data Structures and Algorithms
 * Author: Brittany Hancock
 * Term: Fall 2025
 * 
 * This program compares a simple O(n²) sort (Bubble Sort) 
 * with an efficient O(n log n) sort (Merge Sort).
 * It prints before/after examples and measures runtime 
 * on arrays of various sizes using Stopwatch.
 */

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

            // Test Bubble Sort
            int[] numbers = { 38, 27, 43, 3, 9 };
            Console.WriteLine("Original array: [" + string.Join(", ", numbers) + "]");

            BubbleSort(numbers);

            Console.WriteLine("Sorted array: [" + string.Join(", ", numbers) + "]\n");

            // Test Merge Sort
            int[] numbers2 = { 38, 27, 43, 3, 9 };
            Console.WriteLine("Original array: [" + string.Join(", ", numbers2) + "]");
            MergeSort(numbers2);
            Console.WriteLine("Sorted array: [" + string.Join(", ", numbers2) + "]\n");

            // Performance comparison
            Console.WriteLine("=== Performance Comparison ===\n");
            // Sizes to test
            int[] sizes = { 100, 1000, 10000, 100000 };
            Console.WriteLine($"{"Array Size",-12}{"BubbleSort (ms)",-20}{"MergeSort (ms)",-15}");
            Console.WriteLine(new string('-', 47)); // prints a divider line
            foreach (int size in sizes)
            {
                int[] testArray1 = GenerateRandomArray(size);
                int[] testArray2 = (int[])testArray1.Clone();
                // Measure Bubble Sort time
                Stopwatch stopwatch = Stopwatch.StartNew();
                BubbleSort(testArray1);
                stopwatch.Stop();
                long bubbleSortTime = stopwatch.ElapsedMilliseconds;
                // Measure Merge Sort time
                stopwatch.Restart();
                MergeSort(testArray2);
                stopwatch.Stop();
                long mergeSortTime = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"{size,-12}{bubbleSortTime,-20}{mergeSortTime}");
            }

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

        /// <summary>
        /// Merge Sort Algorithm
        /// </summary>
        /// <param name="arr">array of integers to be sorted</param>
        /// <remarks>Complexity time O(n log n) and space O(n)</remarks>
        static void MergeSort(int[] arr)
        {
            // Base case: if the array has 1 or 0 elements, it is already sorted
            if (arr.Length <= 1)
            {
                return;
            }

            // Split the array into two halves
            int mid = arr.Length / 2;
            int[] left = arr.Take(mid).ToArray();
            int[] right = arr.Skip(mid).ToArray();

            // Recursively sort both halves
            MergeSort(left);
            MergeSort(right);

            // Merge the sorted halves back into the original array
            Merge(arr, left, right);
        }

        /// <summary>
        /// Helper method to merge two sorted arrays into one sorted array
        /// </summary>
        /// <param name="arr">array to hold merged result</param>
        /// <param name="left">array left</param>
        /// <param name="right">array right</param>
        /// <remarks>Complexity time O(n log n) and space O(n)</remarks>
        static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0;  // Index for left array
            int j = 0;  // Index for right array
            int k = 0;  // Index for merged array

            // Compare elements from both arrays and merge them in sorted order
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k++] = left[i++];
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }
            // Copy any remaining elements from the left array
            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }
            // Copy any remaining elements from the right array
            while (j < right.Length)
            {
                arr[k++] = right[j++];
            }
        }

        /// <summary>
        /// Generates an array of random integers of specified size
        /// </summary>
        /// <param name="size">array size</param>
        /// <returns>array of random integers</returns>
        /// <remarks>Complexity time O(n) and space O(n)</remarks>
        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(0, 10000); // Random integers between 0 and 9999
            }
            return arr;
        }
    }
}