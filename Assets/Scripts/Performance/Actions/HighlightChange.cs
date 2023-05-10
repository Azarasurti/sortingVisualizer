

using System;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class HighlightChange : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var oldMin       = step.Left;
            var newMin       = step.Right;
            var cubes        = GameManager.Cubes;
            var cubeSelected = step.Pace.SelectedMaterial;
            var cubeDefault  = Config.DefaultCube;

            CubeController.SetPillarMaterial( cubes[oldMin], cubeDefault );
            CubeController.SetPillarMaterial( cubes[newMin], cubeSelected );

            CodeDictionary.AddMarkLine( step.CodeLineKey );
            await UniTask.Delay( TimeSpan.FromSeconds( step.Lifetime / CubeController.speed.value ) );
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}