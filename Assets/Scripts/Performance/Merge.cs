

namespace Performance
{
    public partial class Step
    {
        public static Step CreateStepForPickAuxiliary( int from, int to, string key = "Pick" )
        {
            var step = new Step
            {
                Left = from,
                Right = to,
                PerformanceEffect = PerformanceEffect.MergePick,
                CodeLineKey = key,
                Pace = new Pace( null, Config.RedCube )
            };
            return step;
        }

        public static Step CreateStepForAuxiliaryBack( int[] snapshot, string key = "Copy" )
        {
            var step = new Step
            {
                Snapshot = snapshot,
                PerformanceEffect = PerformanceEffect.MergeBack,
                CodeLineKey = key,
                Pace = new Pace( null, Config.RedCube )
            };
            return step;
        }

        public static Step CreateStepForMerge( int[] snapshot, int cursor = -1 )
        {
            var step = new Step
            {
                Snapshot = snapshot,
                Cursor = cursor,
                PerformanceEffect = PerformanceEffect.MergeHistory
            };
            return step;
        }
    }
}