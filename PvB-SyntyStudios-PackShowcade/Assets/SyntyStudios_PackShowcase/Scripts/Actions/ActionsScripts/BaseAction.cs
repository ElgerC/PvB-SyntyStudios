using System.Threading;
using Cysharp.Threading.Tasks;
using packShowcase.actions.controller;
using packShowcase.actions.model;
using UnityEngine;

namespace packShowcase.actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        //change origin to the actionController when that is made
        protected BaseActionController origin;
        protected UniTask action;
        [SerializeField] protected BaseActionStatModel statModel;
        private CancellationTokenSource actionCancellationTokenSource = new CancellationTokenSource();

        public async UniTask PerformAsync(BaseActionController actionOrigin)
        {
            origin = actionOrigin;

            var cancellationToken = actionCancellationTokenSource.Token;
            var task = ActionTask().AttachExternalCancellation(cancellationToken);

            await task;
            if(task.Status == UniTaskStatus.Succeeded)
            {
                Destroy(gameObject);
            }
        } 

        protected virtual UniTask ActionTask()
        {
            return UniTask.CompletedTask;
        }

        public virtual void Stop()
        {
            actionCancellationTokenSource.Cancel();
            Destroy(gameObject);
        }
    }
}
