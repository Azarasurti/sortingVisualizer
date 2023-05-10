

using Cysharp.Threading.Tasks;

namespace Performance.Actions
{
    public interface ICubeAction
    {
        public UniTask Perform( Step step );
    }
}