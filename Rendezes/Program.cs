using Rendezes.Sorters;
using System;
using System.Collections.Generic;

namespace Rendezes {
    class Program {

        static void Main(string[] args) {
            TestSorter(new Insertion());
            TestSorter(new Bubble());

            Console.ReadKey();
        }

        private static void TestSorter(ISorter<int> sorter) {
            Random r = new Random();

            Console.WriteLine("Testing: " + sorter.GetType().Name);

            List<int> data = new List<int>();
            List<int> original = new List<int>();
            List<int> expected = new List<int>();

            while (data.Count < 100) {
                int c = r.Next(0, 99999);
                data.Add(c);
                original.Add(c);
                expected.Add(c);
            }

            sorter.Sort(ref data);
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

            if (ok) {
                Console.WriteLine("PASSED");
            } else {
                Console.WriteLine("FAILED");
            }

            Console.WriteLine();
        }
    }
}
