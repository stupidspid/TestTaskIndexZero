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
    [SerializeField]
    private Material defaultMaterial;
    private Text scoreText;
    private Image image;
    private byte score;
    private void Start()
    {
        simplePool.CreateMovingObject();
        scoreText = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
        GetComponentInChildren<Image>().color = Color.red;
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
        simplePool.isButtonClicked = true;
        simplePool.GetPoolObject().transform.position = Vector3.zero;
        simplePool.GetPoolObject().GetComponent<MeshFilter>().mesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshCollider>().sharedMesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshRenderer>().material = defaultMaterial;
        simplePool.GetPoolObject().SetActive(true);
        scoreText.text = score.ToString();
        image.color = Color.green;
        yield return new WaitForSeconds(5f);
        simplePool.isActive = true;
        GetComponentInChildren<Image>().color = Color.red;
    }
}
