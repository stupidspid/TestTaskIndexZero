using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MeshDataInstaller", menuName = "Installers/MeshDataInstaller")]
public class MeshDataInstaller : ScriptableObjectInstaller<MeshDataInstaller>
{
    [SerializeField]
    private MeshData[] meshData;
    public override void InstallBindings()
    {
        Container.BindInstances(meshData);
    }
}