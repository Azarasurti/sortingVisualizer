

using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Performance.Actions
{
    public class JumpOut : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var cube   = GameManager.Cubes[step.Left];
            var target = cube.transform.position + new Vector3( 0, 0, -1f );
            CodeDictionary.AddMarkLine( step.CodeLineKey );
            await CubeController.Move( cube, new[] {new Pace( target, step.Pace.MovingMaterial )} );
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}