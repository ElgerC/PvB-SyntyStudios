using UnityEngine;

namespace packShowcase.targetContainer
{
    public class TargetContainer : MonoBehaviour
    {
        public GameObject target{get; private set;}
        private void Initialize(GameObject startingObject)
        {
            if(startingObject != null)
            {
                target = startingObject;
            }
        }
    }
}