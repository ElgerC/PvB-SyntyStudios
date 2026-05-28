using packShowcase.actions.controller;
using UnityEngine;

namespace packShowcase.targetContainer
{
    public class TargetContainer : MonoBehaviour
    {
        public BaseActionController target{get; private set;}

        public void AssignTarget(BaseActionController newTarget)
        {
            target = newTarget;
        }

        public void UnAssignTarget()
        {
            target = null;
        }
    }
}