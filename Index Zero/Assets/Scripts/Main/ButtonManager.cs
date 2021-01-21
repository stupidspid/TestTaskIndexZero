using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [Inject]
    SimplePool simplePool;
    public void onChangeButtonColor()
    {
        if (simplePool.isButtonClicked)
        {
            GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
