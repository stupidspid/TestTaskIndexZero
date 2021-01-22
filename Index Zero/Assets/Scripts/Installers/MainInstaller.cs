using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public GameObject buttonPrefab;
    public override void InstallBindings()
    {
        Container.Bind<SimplePool>().AsSingle();
        Container.BindFactory<GameObject, MovingObjectFactory>().AsSingle();
    }
}