using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnShop : MonoBehaviour
{
    public string ThisItemId;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<Text>().GetComponent<Text>().text = ItemIds.CoinMyId(ThisItemId);

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponentInChildren<Text>().GetComponent<Text>().text = ItemIds.CoinMyId(ThisItemId);
    }
}
