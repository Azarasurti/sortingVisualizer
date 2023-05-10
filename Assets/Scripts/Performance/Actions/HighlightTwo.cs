

using System;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class HighlightTwo : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var left         = step.Left;
            var right        = step.Right;
            var cubes        = GameManager.Cubes;
            var cubeDefault  = Config.DefaultCube;
            var cubeSelected = step.Pace.SelectedMaterial;

            CodeDictionary.AddMarkLine( step.CodeLineKey );

            CubeController.SetPillarMaterial( cubes[left], cubeSelected );
            CubeController.SetPillarMaterial( cubes[right], cubeSelected );

            await UniTask.Delay( TimeSpan.FromSeconds( step.Lifetime / CubeController.speed.value ) );

            CubeController.SetPillarMaterial( cubes[left], cubeDefault );
            CubeController.SetPillarMaterial( cubes[right], cubeDefault );

            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}