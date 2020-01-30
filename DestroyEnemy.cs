using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyEnemy : MonoBehaviour
{
    private GameObject ES;
    void Awake()
    {
        ES = GameObject.Find("EnemySpawner");
    }
    void Start()
    {
       
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ES.GetComponent<EnemySystem>().enemy_list.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
