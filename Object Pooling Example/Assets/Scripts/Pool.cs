using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private GameObject _poolPrefab;
    private Stack<GameObject> pool = new Stack<GameObject>(); //havuzu Stack ile oluşturduk.

    public Pool(GameObject poolPrefab)
    {
        _poolPrefab = poolPrefab; 
    }

    public void FillPool(int limit)
    {
        for(int i = 0; i< limit; i++)
        {
            GameObject poolObject = Object.Instantiate(_poolPrefab);
            AddPool(poolObject);
        }
    }


    public void AddPool(GameObject poolObject)
    {
        poolObject.gameObject.SetActive(false);
        pool.Push(poolObject); //Stack'e objeyi atıyoruz.
    }

    public GameObject UnloadPool()
    {
        if(pool.Count > 0)
        {
            GameObject _object = pool.Pop();
            return _object;
        }

        return Object.Instantiate(_poolPrefab);
    }
}
