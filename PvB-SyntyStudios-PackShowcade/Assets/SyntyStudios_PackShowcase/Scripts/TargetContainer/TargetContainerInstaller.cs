using packShowcase.targetContainer;
using UnityEngine;
using Zenject;

public class TargetContainerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TargetContainerController>().FromComponentInHierarchy().AsSingle();
    }
}