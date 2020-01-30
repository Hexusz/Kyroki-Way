using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject StartUIlink;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void LoadTwoLanes()
    {
        Application.LoadLevel("Game");
    }
    public void LoadThreeLanes()
    {
        Application.LoadLevel("GameMode3");
    }
    public void EventShowMainMenu()
    {
        MenuUI.SetActive(true);
        StartUIlink.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
