using packShowcase.actions.controller;
using packShowcase.side;
using packShowcase.targetContainer;
using UnityEngine;
using Zenject;

public class TargetMovementController : MonoBehaviour
{
    private TargetContainer[] containers;
    [SerializeField] private TargetInstabilityController baseActionController;
    public int containerIndex{get; private set;}
    [Inject] TargetContainerController targetContainerController;
    public void Initialize(Side originSide)
    {
        containers = targetContainerController.GetTargetContainers(originSide: originSide);
        containerIndex = 1;
        Move(containerIndex);
    }

    public bool MoveInDirection(bool isMovingLeft)
    {
        var dir = isMovingLeft ? -1 : 1;
        var nextContainer = CheckLocation(containerIndex + dir);

        if (!nextContainer)
        {
            return false;
        }

        Move(containerIndex+dir);
        containerIndex += dir;

        return true;
    }

    public void Move(int newContainerIndex)
    {
        var currentContainer = containers[containerIndex];
        var newContainer = containers[newContainerIndex];

        currentContainer.UnAssignTarget();
        newContainer.AssignTarget(baseActionController);

        transform.position = newContainer.gameObject.transform.position;
    }

    private bool CheckLocation(int checkIndex)
    {
        if(checkIndex < 0 || checkIndex >= containers.Length)
        {
            return false;
        }
        return true;
    }
}
