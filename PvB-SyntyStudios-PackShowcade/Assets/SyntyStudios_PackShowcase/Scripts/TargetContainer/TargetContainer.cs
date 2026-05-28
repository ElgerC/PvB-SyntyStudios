using packShowcase.actions.controller;
using UnityEngine;

namespace packShowcase.targetContainer
{
    public class TargetContainer : MonoBehaviour
    {
        public TargetInstabilityController target{get; private set;}

        public void AssignTarget(TargetInstabilityController newTarget)
        {
            target = newTarget;
        }

        public void UnAssignTarget()
        {
            target = null;
        }
    }
}