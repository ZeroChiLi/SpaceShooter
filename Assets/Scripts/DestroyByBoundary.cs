using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        //Destroy(other.gameObject);                //传统方法，直接删除子弹

        other.gameObject.SetActive(false);          //对象池方法，直接把子弹失效就好了
    }


}
