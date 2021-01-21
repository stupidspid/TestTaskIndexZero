using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOMeshInstaller", menuName = "Installers/SOMeshInstaller")]
public class SOMeshInstaller : ScriptableObjectInstaller<SOMeshInstaller>
{
    [SerializeField] MeshData _meshData;
    public override void InstallBindings()
    {
        Container.BindInstance(_meshData);
    }
}