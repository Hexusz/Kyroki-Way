using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PxlSpawn : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject Pxl;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = Timespawn();
        StartCoroutine(coroutine);
        coroutine = Timespawn2();
        StartCoroutine(coroutine);
        coroutine = Timespawn3();
        StartCoroutine(coroutine);
    }
    IEnumerator Timespawn()
    {
        while (true) {
            SpawnPixel();
            yield return new WaitForSeconds(0.5f);
            
        }
    }
    IEnumerator Timespawn2()
    {
        while (true)
        {
            SpawnPixel();
            yield return new WaitForSeconds(0.9f);

        }
    }
    IEnumerator Timespawn3()
    {
        while (true)
        {
            SpawnPixel();
            yield return new WaitForSeconds(1.3f);

        }
    }
    void SpawnPixel()
    {
        Instantiate(Pxl, new Vector3(this.transform.position.x + Random.Range(-3.0f, 3.0f), this.transform.position.y + Random.Range(0f, 5.0f),50), Quaternion.identity);
    }
    void Update()
    {
        
    }
}
