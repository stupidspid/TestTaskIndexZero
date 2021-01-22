using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private SimplePool simplePool;

    private void Start()
    {
        simplePool.CreateMovingObject();
    }
}
