using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [Inject]
    SimplePool simplePool;

    [Inject]
    MeshData[] meshData;

    public Text text;

    private string name;
    private byte score;
    private bool isActive;

    private void Start()
    {
        StartCoroutine(SpawnMovingObject());
    }
    private void onScorePlus()
    {
        score++;
        text.text = score.ToString();
    }

    public void onSetMesh()
    {
        isActive = true;
        name = GetComponentInChildren<Image>().sprite.name;
    }
    private IEnumerator SpawnMovingObject()
    {
        while (true)
        {
            if (simplePool.GetPoolObject() != null && isActive)
            {
                for (int i = 0; i < meshData.Length; i++)
                {
                    if (name.Equals(meshData[i]._Preview.name))
                    {
                        simplePool.GetPoolObject().GetComponent<MeshFilter>().mesh = meshData[i]._Mesh;
                        simplePool.GetPoolObject().GetComponent<MeshCollider>().sharedMesh = meshData[i]._Mesh;
                        simplePool.GetPoolObject().SetActive(true);
                        onScorePlus();
                    }
                }
            }
            yield return new WaitForSeconds(6f);
        }
    }
}