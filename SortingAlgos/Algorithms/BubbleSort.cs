using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    public class BubbleSort : ISorting
    {
        private static BubbleSort _instance = null;
        private BubbleSort() { }

        public static BubbleSort getInstance()
        {
            if (_instance == null)
            {
                _instance = new BubbleSort();
            }

            return _instance;
        }
        public List<int> Sort(List<int> items)
        {
            for (int i = 0; i < (items.Count - 1); i++)
            {
                for (int k = 0; k < (items.Count - 1); k++)
                {
                    if (items[k] > items[k + 1])
                    {
                        int copy = items[k + 1];
                        items[k + 1] = items[k];
                        items[k] = copy;
                    }
                }
            }

            return items;
        }

    }
}
