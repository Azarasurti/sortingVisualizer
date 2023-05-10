

namespace Sorting.Algorithm
{
    public class Shell
    {
        public static void Sort( int[] arr )
        {
            var length = arr.Length;
            for ( var step = length / 2; step >= 1; step /= 2 )
            {
                for ( var i = step; i < length; i++ )
                {
                    var temp = arr[i];
                    var j    = i - step;
                    while ( j >= 0 && arr[j] > temp )
                    {
                        arr[j + step] = arr[j];
                        j -= step;
                    }

                    arr[j + step] = temp;
                }
            }
        }
    }
}