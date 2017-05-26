using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble = 1;

    private Rigidbody itemRb;

    void Start()
    {
        itemRb = GetComponent<Rigidbody>();
        itemRb.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
