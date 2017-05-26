using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    //public GameObject shotObj;
    public GameObject shotSpawn;                //子弹发射的初始化位置

    public float fireRate = 0.2f;               //每次发射子弹事件间隔

    private float nextFire;                     //下一次发射子弹的时间

    void Update()
    {
        if (Time.time > nextFire)               //可以发射子弹时间
        {
            nextFire = Time.time + fireRate;

            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);

            GetComponent<AudioSource>().Play();

            //获取对象池中的子弹
            GameObject bullet = BulletsPool.bulletsPoolInstance.GetPooledObject();
            if(bullet != null)                  //不为空时执行
            {
                bullet.SetActive(true);         //激活子弹并初始化子弹的位置
                bullet.transform.position = shotSpawn.transform.position;
            }
        }
    }
}
