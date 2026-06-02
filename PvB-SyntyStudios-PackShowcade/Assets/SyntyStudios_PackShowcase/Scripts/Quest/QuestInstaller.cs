using UnityEngine;
using Zenject;

public class QuestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<QuestController>().FromComponentInHierarchy().AsSingle();
    }
}