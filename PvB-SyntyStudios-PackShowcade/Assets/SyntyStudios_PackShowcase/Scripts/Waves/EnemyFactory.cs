using packShowcase.actions.controller;
using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [Inject] private DiContainer diContainer;
    [SerializeField] private TargetInstabilityView enemyInstabilityView;
    public void SpawnEnemy(GameObject template)
    {
        var newEnemy = diContainer.InstantiatePrefab(template);
        var actionController = newEnemy.GetComponent<BaseActionController>();

        actionController.TargetInstabilityController.SetInstabilityView(enemyInstabilityView);
        actionController.Initialize();
    }
}
