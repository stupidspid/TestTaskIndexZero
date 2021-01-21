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
    private Image imageButtonColor;

    private byte score;
    private void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        imageButtonColor = GetComponentInChildren<Image>();

        GetComponentInChildren<Image>().color = Color.red;
        simplePool.CreateMovingObject();
    }
    public void SpawnObject()
    {
        if (simplePool.isActive)
        {
            StartCoroutine(SpawnMovingObject());
            simplePool.isActive = false;
        }
    }

    private IEnumerator SpawnMovingObject()
    {
        simplePool.isButtonClicked = true;

        simplePool.GetPoolObject().transform.position = Vector3.zero;
        simplePool.GetPoolObject().GetComponent<MeshFilter>().mesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshCollider>().sharedMesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshRenderer>().material = defaultMaterial;
        simplePool.GetPoolObject().SetActive(true);

        score++;
        scoreText.text = score.ToString();

        imageButtonColor.color = Color.green;

        yield return new WaitForSeconds(5f);

        simplePool.isActive = true;
        GetComponentInChildren<Image>().color = Color.red;
    }
}
