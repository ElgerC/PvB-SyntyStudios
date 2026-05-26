using UnityEngine;

namespace packShowcase.targetContainer
{
    public class TargetContainer : MonoBehaviour
    {
        public GameObject target{get; private set;}

        public void AssignTarget(GameObject newTarget)
        {
            target = newTarget;
        }

        public void UnAssignTarget()
        {
            target = null;
        }
    }
}