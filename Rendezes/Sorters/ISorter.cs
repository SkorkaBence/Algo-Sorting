using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {

    interface ISorter<T> {

        void Sort(ref List<T> input);

    }
}
