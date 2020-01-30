using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelCreate : MonoBehaviour
{
    private SpriteRenderer _mySprite;
    private Transform _myTransform;
    private IEnumerator coroutine;
    Color color = new Color(0, 0, 0, 0.95f);
    float s;
    // Start is called before the first frame update

    void Start()
    {
        _mySprite = this.gameObject.GetComponent<SpriteRenderer>();
        _myTransform = this.gameObject.transform;

        s = Random.Range(3, 8);
        _myTransform.localScale = new Vector3(s, s, 0);
        _mySprite.color = color;
        coroutine = Timespawn();
        StartCoroutine(coroutine);
        
    }
    IEnumerator Timespawn()
    {
        float range= Random.Range(-7, 7);
        float range2= Random.Range(-7, 7);
        float range3= Random.Range(-5, 5);
        float i = 1f;
        while (true)
        {
            i -= 0.01f;
            yield return new WaitForSeconds(0.02f);
            _mySprite.color = new Color(0, 0, 0, i);
            _myTransform.localScale += new Vector3(0.1F, 0.1F, 0);
            _myTransform.position += new Vector3(0f, -0.07f, 0);
            _myTransform.Rotate(new Vector3(range, range2, range3));
            if (i <= 0)
            {
                Destroy(this.gameObject);
            }
                
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
