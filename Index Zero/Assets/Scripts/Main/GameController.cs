using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class GameController : MonoBehaviour
{
    [Inject]
    private SimplePool simplePool;
    [SerializeField]
    private MeshData meshData;
    private Text scoreText;
    private byte score;
    private void Start()
    {
        simplePool.CreateMovingObject();
        scoreText = GetComponentInChildren<Text>();
    }
    public void onClick()
    {
        if (simplePool.isActive)
        { 
            StartCoroutine(SpawnMovingObject());
            simplePool.isActive = false;
        }
    }

    private IEnumerator SpawnMovingObject()
    {     
        score++;
        simplePool.GetPoolObject().transform.position = Vector3.zero;
        simplePool.GetPoolObject().GetComponent<MeshFilter>().mesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshCollider>().sharedMesh = meshData._Mesh;
        simplePool.GetPoolObject().SetActive(true);
        scoreText.text = score.ToString();
        yield return new WaitForSeconds(5f);
        simplePool.isActive = true;
    }
}
