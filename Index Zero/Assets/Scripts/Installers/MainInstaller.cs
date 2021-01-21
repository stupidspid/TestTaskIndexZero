using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SimplePool>().AsSingle();
        Container.Bind<GameController>().AsSingle();
        Container.BindFactory<GameObject, MovingObjectFactory>().AsSingle();
    }
}