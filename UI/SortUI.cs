using System;
using System.Security.Cryptography;

namespace Sanity404Studios.Sorting
{
    public static class SortUI
    {
        public static void Main(string[] args)
        {
            Bogosort bSort = new Bogosort();
            RandomNumberGenerator cryptRand = RandomNumberGenerator.Create();
            Random rand = new Random();

            int size = rand.Next(2, 10);
            Console.WriteLine("Sorting " + size + " random numbers...");

            byte[] data = new byte[size];
            int[] byteData = new int[size];
            int[] dataSorted;

            cryptRand.GetBytes(data);

            for (int i = 0; i < size; i++)
            {
                byteData[i] = data[i];
            }


            dataSorted = bSort.Sort(byteData);

            for (int i = 0; i < dataSorted.Length; i++)
            {
                Console.WriteLine(dataSorted[i]);
            }

            Console.WriteLine("Sorted " + size + " random numbers.");
            Console.ReadKey();
        }
    }
}