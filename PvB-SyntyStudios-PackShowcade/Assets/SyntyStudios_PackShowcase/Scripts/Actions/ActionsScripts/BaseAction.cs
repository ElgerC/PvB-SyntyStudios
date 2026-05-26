using Cysharp.Threading.Tasks;
using packShowcase.actions.model;
using UnityEngine;

namespace packShowcase.actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        //change origin to the actionController when that is made
        private GameObject origin;
        protected UniTask action;
        [SerializeField] protected BaseActionStatModel statModel;

        public async UniTask PerformAsync(GameObject origin)
        {
            
        } 

        protected virtual UniTask ActionTask()
        {
            return UniTask.CompletedTask;
        }
    }
}
