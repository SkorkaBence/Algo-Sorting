using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {
    class Quicksort : ISorter<int> {

        public void Sort(ref List<int> input) {
            Qsort(ref input, 0, input.Count - 1);
        }

        private void Qsort(ref List<int> A, int from, int to) {
            if (from < to) {
                int p = Psort(ref A, from, to);
                Qsort(ref A, from, p - 1);
                Qsort(ref A, p + 1, to);
            }
        }

        private int Psort(ref List<int> A, int from, int to) {
            int pivot = A[to];
            int i = from - 1;
            for (int j = from; j < to; j++) {
                if (A[j] < pivot) {
                    i++;
                    int x = A[i];
                    A[i] = A[j];
                    A[j] = x;
                }
            }
            if (A[to] < A[i + 1]) {
                int x = A[i + 1];
                A[i + 1] = A[to];
                A[to] = x;
            }
            return i + 1;
        }

    }
}
