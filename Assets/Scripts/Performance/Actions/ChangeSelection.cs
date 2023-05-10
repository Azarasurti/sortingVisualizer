﻿

using System;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class ChangeSelection : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            var index        = step.Left;
            var cubes        = GameManager.Cubes;
            var cubeSelected = step.Pace.SelectedMaterial;
            var cubeDefault  = Config.DefaultCube;

            CubeController.SetPillarMaterial( cubes[index], cubeSelected );
            if ( index - 1 > step.Right ) CubeController.SetPillarMaterial( cubes[index - 1], cubeDefault );

            CodeDictionary.AddMarkLine( step.CodeLineKey );
            await UniTask.Delay( TimeSpan.FromSeconds( step.Lifetime / CubeController.speed.value ) );
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}