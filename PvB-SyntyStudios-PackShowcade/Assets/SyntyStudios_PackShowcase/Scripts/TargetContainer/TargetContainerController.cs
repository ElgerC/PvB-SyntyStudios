using packShowcase.side;
using UnityEngine;

namespace packShowcase.targetContainer
{
   public class TargetContainerController : MonoBehaviour
    {
        [SerializeField] private TargetContainer[] playerTargetContainers;
        [SerializeField] private TargetContainer[] enemyTargetContainers;

        //change GameObject to dmg system later
        public GameObject GetTargetAtLocation(int locationIndex, Side targetSide)
        {
            var target = playerTargetContainers[0].target;

            switch (targetSide)
            {
                case Side.player:
                    target = playerTargetContainers[locationIndex].target;
                    break;
                case Side.enemy:
                    target = enemyTargetContainers[locationIndex].target;
                    break;
            }

            return target;
        }

        public int GetLocationOfSide(Side side)
        {
            var sideContainers = playerTargetContainers;
            var containerIndex = 0;

            switch (side)
            {
                case Side.player:
                    sideContainers = playerTargetContainers;
                    break;
                case Side.enemy:
                    sideContainers = enemyTargetContainers;
                    break;
            }

            for (int i = 0; i < sideContainers.Length; i++)
            {
                if(sideContainers[i].target != null)
                {
                    containerIndex = i;
                }
            }

            return containerIndex;
        }
    } 
}

