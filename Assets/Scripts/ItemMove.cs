using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody itemRb;

    void Start()
    {
        itemRb = GetComponent<Rigidbody>();
        itemRb.velocity = new Vector3(0, 0, speed);
    }

}
