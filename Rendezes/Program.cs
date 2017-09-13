using Rendezes.Sorters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ImageSharp;

namespace Rendezes {
    class Program {

        static void Main(string[] args) {
            TestSorter(new Insertion());
            TestSorter(new Bubble());
            TestSorter(new Merge());
            TestSorter(new Quicksort());

            Console.ReadKey();
        }

        private static void TestSorter(Sorter<int> sorter) {
            Random r = new Random();

            Console.WriteLine("Testing: " + sorter.GetType().Name);

            int[] amounts = new int[] { 100, 1000, 10000, 20000 };

            foreach (int amount in amounts) {
                List<int> data = new List<int>();
                List<int> original = new List<int>();
                List<int> expected = new List<int>();

                //sorter.EnableSaveStates = amount <= 100;

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

                if (sorter.EnableSaveStates) {
                    Console.WriteLine("Saving images...");
                    List<int[]> steps = sorter.getStates();
                    int stepnum = 1;
                    foreach (int[] state in steps) {
                        int height = (amount / 16 * 9);
                        Image<Rgba32> img = new Image<Rgba32>(amount, height);
                        for (int x = 0; x < amount; x++) {
                            int convval = (int)Math.Floor((double)state[x] / 99999 * height);

                            for (int h = 0; h < height; h++) {
                                int y = height - h - 1;

                                if (h > convval) {
                                    img[x, y] = Rgba32.White;
                                } else {
                                    img[x, y] = Rgba32.DarkGreen;
                                }
                            }
                        }
                        //img.Resize(1920, 1080);
                        img.Save("D:\\sort\\" + sorter.GetType().Name + "-" + amount + "-" + stepnum + ".png");
                        stepnum++;
                    }
                }

            }

            Console.WriteLine();
        }
    }
}
