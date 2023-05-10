

using System.Collections.Concurrent;

namespace Performance.Actions
{
    public static class Tabernacle
    {
        public static readonly ConcurrentQueue<Step> Image = new ConcurrentQueue<Step>();
    }
}