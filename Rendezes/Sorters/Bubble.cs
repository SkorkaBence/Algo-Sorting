using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {
    class Bubble : Sorter<int> {

        public override void Sort(ref List<int> input) {
            for (int i = input.Count - 1; i >= 0; i--) {
                for (int j = 0; j <= i - 1; j++) {
                    if (input[j] > input[j + 1]) {
                        int a = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = a;

                        this.SaveState(ref input);
                    }
                }
            }
        }

    }
}
