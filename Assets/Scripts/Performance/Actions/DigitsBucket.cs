

using System.Collections.Generic;

namespace Performance.Actions
{
    public static class DigitsBucket
    {
        public static Stack<int>[] buckets;

        public static void ResetBuckets()
        {
            buckets = new[]
            {
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>()
            };
        }
    }
}