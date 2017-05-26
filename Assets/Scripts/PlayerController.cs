using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float displayMinX, displayMaxX, displayMinZ, displayMaxZ;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float tilt = 5;
    public Boundary boundary;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody playerRb;

    public GameObject shotObj;
    public GameObject shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire;

    public GameObject explosion;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetButton("Fire1") && Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);
        //    GetComponent<AudioSource>().Play();
        //}
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(moveHorizontal * speed, 0, moveVertical * speed);
        playerRb.position = new Vector3(Mathf.Clamp(playerRb.position.x, boundary.displayMinX, boundary.displayMaxX), 0, Mathf.Clamp(playerRb.position.z, boundary.displayMinZ, boundary.displayMaxZ));

        playerRb.rotation = Quaternion.Euler(0, 0, -playerRb.velocity.x * tilt);
    }

    public void PlayerDie()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

}
