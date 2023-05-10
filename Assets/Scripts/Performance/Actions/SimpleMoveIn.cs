

using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Performance.Actions
{
    public class SimpleMoveIn : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            CodeDictionary.AddMarkLine( step.CodeLineKey );
            
            while ( Tabernacle.Image.TryDequeue( out var fromTo ) )
            {
                var cube = GameManager.Cubes[fromTo.Left];
                if ( cube.transform.position.z != 0 )
                {
                    await CubeController.Move( cube, new[]
                    {
                        new Pace( cube.transform.parent.position + new Vector3( fromTo.Right * Config.HorizontalGap, 0, 0f ), step.Pace.MovingMaterial )
                    } );
                }
            }

            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
            
            GameManager.GenObjectsFromArray( step.Snapshot );

            Interlocked.Increment( ref CubeController.rewindIndex );
        }
    }
}