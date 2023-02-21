using System;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int[] array = new int[1000000];
            int[] array1 = new int[array.Length];


            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-array.Length, array.Length);
                array1[i] = array[i];
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            array = Non_Recursive_MergeSort(array);
            //printArray(array);

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is Non-Recursive MergeSort " + stopwatch.ElapsedMilliseconds + " ms ");

            stopwatch = new Stopwatch();
            stopwatch.Start();

            MergeSort(array1, 0, array1.Length - 1);

            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is Merge Sort " + stopwatch.ElapsedMilliseconds + " ms ");


            //Test results
            bool result = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array1[i])
                {
                    result = false;
                    break;
                }
            }

            Console.WriteLine("Test results : " + result);



            Console.ReadLine();
        }


        static void printArray(int[] arr)
        {
            int n = arr.Length;
            string str = "";
            for (int i = 0; i < n; ++i)
                str += arr[i] + " ";
            Console.WriteLine(str);
        }

        private static bool Sawp(int[] array, int start, int end)
        {
            if (array[start] > array[end])
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                return true;
            }
            return false;
        }



        private static int[] Non_Recursive_MergeSort(int[] inArray)
        {

            int step = 2;
            int stepLength = inArray.Length / step;
            int[] outArray = new int[inArray.Length];

            while (step / 2 < inArray.Length)
            {
                for (int i = 0; i < stepLength * step; i += step)
                {
                    MergeArray(inArray, outArray, i, i + step / 2, i + step);
                }

                if (inArray.Length - stepLength * step > step / 2)
                {
                    MergeArray(inArray, outArray, stepLength * step, stepLength * step + step / 2, inArray.Length);
                }
                else
                {
                    for (int i = stepLength * step; i < inArray.Length; i++)
                    {
                        outArray[i] = inArray[i];
                    }
                }

                step *= 2;
                stepLength = inArray.Length / step;

                var arraySawp = inArray;
                inArray = outArray;
                outArray = arraySawp;
            }
            return inArray;
        }

        private static void MergeArray(int[] inArray, int[] outArray, int start, int middle, int end)
        {
            int index = start;
            int mid = middle;
            while (start < middle && mid < end)
            {
                if (inArray[start] < inArray[mid])
                    outArray[index] = inArray[start++];
                else
                    outArray[index] = inArray[mid++];

                index++;
            }


            while (start < middle)
            {
                outArray[index] = inArray[start];
                index++;
                start++;
            }


            while (mid < end)
            {
                outArray[index] = inArray[mid];
                index++;
                mid++;
            }

        }


        static void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }


        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }


    }


}

