using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private int speed = 2;

    private Rigidbody rigidbodyMovingObject;
    private void Start()
    {
        rigidbodyMovingObject = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidbodyMovingObject.position += Vector3.right * Time.deltaTime * speed;
        if (rigidbodyMovingObject.position.x >= 23)
        {
            gameObject.SetActive(false);
            gameObject.transform.position = Vector3.zero;
        }
    }
}