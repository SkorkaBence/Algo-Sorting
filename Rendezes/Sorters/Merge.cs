using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {
    class Merge : ISorter<int> {

        public void Sort(ref List<int> input) {
            SplitI(ref input, 0, input.Count - 1);
        }

        private void SplitI(ref List<int> A, int from, int to) {
            if (from < to) {
                int k = (to + from) / 2;
                SplitI(ref A, from, k);
                SplitI(ref A, k + 1, to);
                MergeI(ref A, from, k, to);
            }
        }

        private void MergeI(ref List<int> original, int from, int splitpoint, int to) {
            //List<int> original = new List<int>(A.ToArray());
            List<int> copy = new List<int>(original.ToArray());

            int index1 = from;
            int index2 = splitpoint + 1;
            int index = from;

            while (index1 <= splitpoint || index2 <= to) {
                if ((index2 > to) || (index1 <= splitpoint && original[index1] < original[index2])) {
                    //A.Add(original[index1]);
                    copy[index] = original[index1];
                    index++;
                    index1++;
                } else if (index1 <= splitpoint && index2 <= to && original[index1] == original[index2]) {
                    copy[index] = original[index1];
                    index++;
                    copy[index] = original[index2];
                    index++;
                    index1++;
                    index2++;
                } else if ((index1 > splitpoint) || (index2 <= to && original[index2] < original[index1])) {
                    copy[index] = original[index2];
                    index++;
                    index2++;
                }
            }

            original = copy;
        }

    }
}
