using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Pool;

public class Spawning : MonoBehaviour
{
    ObjectPool<GameObject> objectPool;
    ListPool<GameObject> lispool;
    [SerializeField] GameObject Cube, Sphere;
    void Start()
    {
        objectPool = new ObjectPool<GameObject>(CreateObject, OnTakeBulletFromPool, OnRetunrTOpool, DestroyGameobject, true, 100, 100);
        lispool=new ListPool<GameObject>();
    }


    private GameObject CreateObject()
    {
        GameObject tempObject = Instantiate(Cube);
        return tempObject;
    }

    private void OnTakeBulletFromPool(GameObject thisgameobject)
    {
        thisgameobject.transform.localPosition = Vector3.zero;
        thisgameobject.SetActive(true);
    }



    private void OnRetunrTOpool(GameObject thisgameobject)
    {
        thisgameobject.SetActive(false);
    }

    private void DestroyGameobject(GameObject thisgameobject)
    {
        Destroy(thisgameobject);
    }
}
