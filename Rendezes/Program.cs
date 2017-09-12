using Rendezes.Sorters;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rendezes {
    class Program {

        static void Main(string[] args) {
            TestSorter(new Insertion());
            TestSorter(new Bubble());
            TestSorter(new Merge());
            TestSorter(new Quicksort());

            Console.ReadKey();
        }

        private static void TestSorter(ISorter<int> sorter) {
            Random r = new Random();

            Console.WriteLine("Testing: " + sorter.GetType().Name);

            int[] amounts = new int[] { 1, 10, 100, 1000, 10000 };

            foreach (int amount in amounts) {
                List<int> data = new List<int>();
                List<int> original = new List<int>();
                List<int> expected = new List<int>();

                while (data.Count < amount) {
                    int c = r.Next(0, 99999);
                    data.Add(c);
                    original.Add(c);
                    expected.Add(c);
                }

                Stopwatch sw = new Stopwatch();
                sw.Start();
                sorter.Sort(ref data);
                sw.Stop();

                bool ok = true;
                for (int i = 1; i < data.Count; i++) {
                    if (data[i] < data[i - 1]) {
                        ok = false;
                        break;
                    }
                }

                if (!ok) {
                    expected.Sort();
                    Console.WriteLine("       IN     OUT    EXPECTED STATUS");
                    for (int i = 0; i < data.Count; i++) {
                        string status = (data[i] == expected[i] ? "OK" : "FAILED");
                        Console.WriteLine($"{i:000000} {original[i]:000000} {data[i]:000000} {expected[i]:000000}   {status}");
                    }
                    Console.WriteLine();
                }

                string amm = $"{amount}".PadRight(6, ' ');

                if (ok) {
                    Console.WriteLine($"PASSED ({amm} items {sw.Elapsed})");
                } else {
                    Console.WriteLine($"FAILED ({amm} items {sw.Elapsed})");
                }

            }

            Console.WriteLine();
        }
    }
}
