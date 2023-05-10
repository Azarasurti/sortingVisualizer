

using System;
using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public class CodeHighlight : ICubeAction
    {
        public async UniTask Perform( Step step )
        {
            CodeDictionary.AddMarkLine( step.CodeLineKey );
            await UniTask.Delay( TimeSpan.FromSeconds( step.Lifetime / CubeController.speed.value ) );
            CodeDictionary.RemoveMarkLine( step.CodeLineKey );
        }
    }
}