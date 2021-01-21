﻿using UnityEngine;
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
        score++;
        simplePool.GetPoolObject().transform.position = Vector3.zero;
        simplePool.GetPoolObject().GetComponent<MeshFilter>().mesh = meshData._Mesh;
        simplePool.GetPoolObject().GetComponent<MeshCollider>().sharedMesh = meshData._Mesh;
        simplePool.GetPoolObject().SetActive(true);
        scoreText.text = score.ToString();
    }
}