using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject SettingsUIlink;
    public Slider SoundSlider;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void EventShowMainMenu()
    {
        MenuUI.SetActive(true);
        SettingsUIlink.SetActive(false);

    }
    public void ChangeSound()
    {


        {
            PlayerPrefs.SetFloat("Sound", SoundSlider.value);
            AudioListener.volume = SoundSlider.value;
        }
        //Сохраним внесенные изменения 
        PlayerPrefs.Save();
        //Debug.Log("Звук = " + PlayerPrefs.GetFloat("Sound"));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
