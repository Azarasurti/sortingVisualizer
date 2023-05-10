

using System.Threading;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class MergeHistory : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            Interlocked.Increment( ref CubeController.rewindIndex );
            await UniTask.Yield();
        }
    }
}