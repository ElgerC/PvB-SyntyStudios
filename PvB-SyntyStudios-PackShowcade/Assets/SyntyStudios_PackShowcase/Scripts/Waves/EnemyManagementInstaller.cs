using UnityEngine;
using Zenject;

public class EnemyManagementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<WaveController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyFactory>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}