using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuUI;
    public GameObject ShopUIlink;
    public Text PlusCoinText;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void EventShowMainMenu()
    {
        MenuUI.SetActive(true);
        ShopUIlink.SetActive(false);

    }
    public void CarBtn()
    {

    }
    // Update is called once per frame
    void Update()
    {
        PlusCoinText.text = PlayerPrefs.GetInt("PlusCoin").ToString();
    }
}
