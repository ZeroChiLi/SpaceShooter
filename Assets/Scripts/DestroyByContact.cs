using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    void Start()
    {
        Type type = Type.GetType("Mono.Runtime");
        if (type != null)
        {
            MethodInfo info = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);

            if (info != null)
                Debug.Log(info.Invoke(null, null));
        }

        GameObject gameControllorObject = GameObject.FindWithTag("GameController");
        if(gameControllorObject != null)
            gameController = gameControllorObject.GetComponent<GameController>();
        if (gameController == null)
            Debug.Log("can not find GameController!!!!!");
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (tag == "Player")
        {
            if (other.tag == "PlayerBullet" || other.tag == "Boundary")
                return;
            gameController.GameOver();
        }
        else if (other.tag != "Player" && other.tag != "PlayerBullet")
            return;
        if(other.tag == "Player")
        {
            if(playerExplosion != null)
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        if(explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

}


