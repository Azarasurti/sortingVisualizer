
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class SimpleSwap : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var cubes       = GameManager.Cubes;
            var cubeDefault = Config.DefaultCube;
            var left        = step.Left;
            var right       = step.Right;

            
            GameManager.Cubes.Swap( left, right );
            
            CodeDictionary.AddMarkLine( step.CodeLineKey );

            
            await CubeController.SwapTwoObjectPosition( cubes[left], cubes[right], step.Pace );

            
            CubeController.SetPillarMaterial( cubes[left], cubeDefault );
            CubeController.SetPillarMaterial( cubes[right], cubeDefault );
            
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );

            Interlocked.Increment( ref CubeController.rewindIndex );
        }
    }
}