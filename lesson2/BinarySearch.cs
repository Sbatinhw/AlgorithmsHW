using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW
{
    class BinarySearch
    {
        public static int BinSearch(int[] array, int value)
        {
            int low = 0;
            int top = array.Length - 1;
            while(low <= top)
            {
                int mid = (low + top) / 2;
                if(array[mid] == value) { return mid; }
                else if (array[mid] < value) { low = mid + 1; }
                else if (array[mid] > value) { top = mid - 1; }
            }
            return -1;
        }



        //
    }
}
