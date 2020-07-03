using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public GameObject BulletPrefab; //oluşturduğum prefab'in atamasını Inspector'dan yapacağım.
    private Pool _pool;
    [SerializeField]
    public GameObject _turret;


    private void Start()
    {
        _pool = new Pool(BulletPrefab);
        _pool.FillPool(5); //Havuzu start kısmında dolduruyorum. 

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletObject = _pool.UnloadPool();
            bulletObject.gameObject.SetActive(true);
            StartCoroutine(BulletDestory(4f, bulletObject));
        }
    }

    IEnumerator BulletDestory(float min, GameObject _bullet)
    {
        yield return new WaitForSeconds(min);
        _pool.AddPool(_bullet);
    }

}
