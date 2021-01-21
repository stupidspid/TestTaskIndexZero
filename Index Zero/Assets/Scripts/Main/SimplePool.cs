using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimplePool
{ 
    [Inject]
    private MovingObjectFactory movingObject;
    public List<GameObject> movingObjects = new List<GameObject>();

    public void CreateMovingObject()
    {
        GameObject temp = movingObject.Create();
        temp.AddComponent<MeshFilter>();
        temp.AddComponent<MeshRenderer>();
        temp.AddComponent<MeshCollider>().convex = true;
        temp.AddComponent<Rigidbody>();
        temp.AddComponent<MovingObject>();
        temp.SetActive(false);
        movingObjects.Add(temp);
    }

    public GameObject GetPoolObject()
    {
        for(int i = 0; i<movingObjects.Count; i++)
        {
            if(!movingObjects[i].activeInHierarchy)
            {
                return movingObjects[i];
            }
        }
        return null;
    }
}
public class MovingObjectFactory : PlaceholderFactory<GameObject> { }
