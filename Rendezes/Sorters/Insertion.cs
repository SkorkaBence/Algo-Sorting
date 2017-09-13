using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {
    class Insertion : Sorter<int> {


        public override void Sort(ref List<int> input) {
            for (int i = 1; i < input.Count; i++) {
                if (input[i] < input[i - 1]) {
                    int x = input[i];
                    input[i] = input[i - 1];
                    int j = i - 2;

                    this.SaveState(ref input);

                    while (j >= 0 && input[j] > x) {
                        input[j + 1] = input[j];
                        j--;

                        this.SaveState(ref input);
                    }
                    input[j + 1] = x;
                }
            }
        }


    }
}
