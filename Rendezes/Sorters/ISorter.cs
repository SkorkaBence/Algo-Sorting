using System;
using System.Collections.Generic;
using System.Text;

namespace Rendezes.Sorters {

    abstract class Sorter<T> {

        private List<T[]> states = new List<T[]>();
        public bool EnableSaveStates = false;

        public Sorter() : this(false) {
        }

        public Sorter(bool save) {
            EnableSaveStates = save;
        }

        public abstract void Sort(ref List<T> input);

        protected void SaveState(ref List<T> state) {
            if (EnableSaveStates) {
                states.Add(state.ToArray());
            }
        }

        public List<T[]> getStates() {
            return states;
        }

    }
}
