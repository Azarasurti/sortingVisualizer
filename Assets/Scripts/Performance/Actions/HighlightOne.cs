

using System;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class HighlightOne : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var index = step.Left;
            var cubes = GameManager.Cubes;
            
            CodeDictionary.AddMarkLine( step.CodeLineKey );
            
            CubeController.SetPillarMaterial( cubes[index], step.Pace.SelectedMaterial );
            await UniTask.Delay( TimeSpan.FromSeconds( step.Lifetime / CubeController.speed.value ) );
            CubeController.SetPillarMaterial( cubes[index], step.Pace.MovingMaterial );
            
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}