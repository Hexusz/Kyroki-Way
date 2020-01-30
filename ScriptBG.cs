using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBG : MonoBehaviour
{
    public Material[] materialArray;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void goBackroundSet(int bg)
    {
        this.GetComponent<Renderer>().material = materialArray[bg];
    }
    // Update is called once per frame
    void Update()
    {

    }
}
