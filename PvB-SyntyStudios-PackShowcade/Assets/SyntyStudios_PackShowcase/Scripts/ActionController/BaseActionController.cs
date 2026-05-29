using Cysharp.Threading.Tasks;
using packShowcase.side;
using UnityEngine;
using Zenject;

namespace packShowcase.actions.controller
{
    public abstract class BaseActionController : MonoBehaviour
    {
        private bool isActing = true;
        [Inject] private DiContainer diContainer;
        [SerializeField] private GameObject actionHolder;
        public GameObject modelHolder;
        [SerializeField] private Side side;
        public Side Side => side;
        [SerializeField] private TargetMovementController movementController;
        protected BaseAction currentAction;
        public TargetMovementController MovementController => movementController;
        [SerializeField] private TargetInstabilityController targetInstabilityController;
        public TargetInstabilityController TargetInstabilityController => targetInstabilityController;

        public virtual void Initialize()
        {
            movementController.Initialize(side);
            targetInstabilityController.Initialize();
        }

        protected virtual async UniTask PlayAction(GameObject actionTemplate)
        {
            if (isActing == false || currentAction != null)
            {
                return;
            }

            var direction = actionHolder.transform.rotation;
            var actionObject = diContainer.InstantiatePrefab(actionTemplate,actionHolder.transform.position,direction,actionHolder.transform);
            var action = actionObject.GetComponent<BaseAction>();

            currentAction = action;
            await action.PerformAsync(actionOrigin: this);
            currentAction = null;
        }

        public bool TryInterruptAction()
        {
            InterruptableAttackAction interruptableAttackAction = null;
            currentAction?.TryGetComponent<InterruptableAttackAction>(out interruptableAttackAction);

            if(interruptableAttackAction != null)
            {
                interruptableAttackAction.Interrupt();
                return true;
            }
            return false;
        }
    }
}
