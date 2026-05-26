using Cysharp.Threading.Tasks;
using packShowcase.side;
using UnityEngine;

namespace packShowcase.actions.controller
{
    public abstract class BaseActionController : MonoBehaviour
    {
        private bool isActing;
        private BaseAction currentAction;
        [SerializeField] private GameObject actionHolder;
        [SerializeField] private Side side;
        [SerializeField] private TargetMovementController movementController;
        public TargetMovementController MovementController => movementController;

        void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            movementController.Initialize(side);
        }

        protected virtual async UniTask PlayAction(GameObject actionTemplate)
        {
            if (isActing == false || currentAction != null)
            {
                return;
            }

            var actionObject = Instantiate(actionTemplate,actionHolder.transform.position,Quaternion.identity);
            var action = actionObject.GetComponent<BaseAction>();

            await action.PerformAsync(actionOrigin: this);
        }
    }
}
