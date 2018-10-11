using System;
using System.Collections.Generic;
using System.Data;

namespace Sanity404Studios.Sorting
{
    public class Bogosort
    {
        private readonly Random _rand;

        public Bogosort()
        {
            _rand = new Random();
        }

        /// <summary>
        /// Sorts ints via bogo sort. Duplicate items will cause infinite loop.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int[] Sort(int[] input)
        {
            int size = input.Length;
            int iterations = 0;
            int[] indexArr = new int[size];
            int[] sorted = new int[size];

            // 
            for (int i = 0; i < size; i++)
            {
                sorted[i] = input[i];
            }

            List<int> usedNumbers = new List<int>();

            bool beenSorted = false;
            bool containsAll = false;

            while (false == containsAll)
            {
                while (false == beenSorted)
                {
                    // Check if array is in order
                    for (int i = 1; i <= size; i++)
                    {
                        if ((size == i && sorted[i - 1] < sorted[i - 2]) || (size != i && sorted[i] < sorted[i - 1]))
                        {
                            break;
                        }
                        // Detects the case of being at the end of array
                        else if ((size == i && sorted[i - 1] > sorted[i - 2]))
                        {
                            List<int> contains = new List<int>();
                            contains.AddRange(sorted);

                            if (true == ContainsAll(contains, input))
                            {
                                return sorted;
                            }
                        }
                    }

                    // Creates the random array of indexes
                    for (int i = 0; i < size; i++)
                    {
                        bool used = false;

                        while (false == used)
                        {
                            int result = _rand.Next(size);

                            if (false == usedNumbers.Contains(result))
                            {
                                usedNumbers.Add(result);
                                indexArr[i] = result;
                                used = true;
                            }
                        }
                    }

                    usedNumbers.Clear();

                    // Assigns to the input array
                    for (int i = 0; i < size; i++)
                    {
                        int r = input[indexArr[i]];
                        sorted[i] = r;
                    }
                    iterations++;
                    Console.WriteLine("Number of iterations: " + iterations);
                }
            }
            return null;
        }

        /// <summary>
        /// Checks to make sure that all numbers are there in the sorted array
        /// </summary>
        /// <param name="sortedLst"></param>
        /// <param name="arrToCheck"></param>
        /// <returns></returns>
        private static bool ContainsAll(ICollection<int> sortedLst, IReadOnlyList<int> arrToCheck)
        {
            for (int i = 0; i < sortedLst.Count; i++)
            {
                if (false == sortedLst.Contains(arrToCheck[i]))
                {
                    return false;
                }
                else if ((true == sortedLst.Contains(arrToCheck[i])) && (sortedLst.Count - 1 == i))
                {
                    return true;
                }
                else if (true == sortedLst.Contains(arrToCheck[i]))
                {
                    // Do nothing
                }
                else
                {
                    throw new ConstraintException("Fell into else block. Check inputs.");
                }
            }

            throw new ConstraintException("ContainsAll did not return anything.");
        }
    }
}