using packShowcase.actions.controller;
using packShowcase.side;
using UnityEngine;

namespace packShowcase.targetContainer
{
   public class TargetContainerController : MonoBehaviour
    {
        [SerializeField] private TargetContainer[] playerTargetContainers;
        [SerializeField] private TargetContainer[] enemyTargetContainers;

        //change GameObject to dmg system later
        public BaseActionController GetTargetAtLocation(int locationIndex, Side targetSide)
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

        public TargetContainer[] GetTargetContainers(Side originSide)
        {
            var sideContainers = playerTargetContainers;

            switch (originSide)
            {
                case Side.player:
                    sideContainers = playerTargetContainers;
                    break;
                case Side.enemy:
                    sideContainers = enemyTargetContainers;
                    break;
            }

            return sideContainers;
        }
    } 
}

