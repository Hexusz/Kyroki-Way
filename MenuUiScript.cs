using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class MenuUiScript : MonoBehaviour
{
    float speedR, speedG, speedB, speedMultiple = 3f;
    public GameObject MainCamera;
    public GameObject StartUI;
    public GameObject MenuUI;
    public GameObject SettingsUI;
    public GameObject ShopUIlink;
    public GameObject About;
    public GameObject BtnLeaderBoard;
    public Text BestScoreText;
    public Text BestScoreTextDown;
    public Slider SoundSlider;
    private bool __auth;
    public GameObject GoogleGameslink;
    private const float FontSizeMult = 0.05f;
    private bool mWaitingForAuth = false;
    private string mStatusText = "Ready.";

    //public GameObject MenuUI;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlusCoin") == false)//Проверка на первый запуск
        {
            PlayerPrefs.SetInt("PlusCoin", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("BestScore") == false)//Проверка на первый запуск
        {
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("Sound") == false)//Проверка на первый запуск
        {
            PlayerPrefs.SetFloat("Sound", 1);
            PlayerPrefs.Save();
        }
    }
    public bool Authenticated
    {
        get
        {
            return Social.Active.localUser.authenticated;
        }
    }
    public void GoogleAuth()
    {
        if (mWaitingForAuth)
        {
            return;
        }




        if (!Social.localUser.authenticated)
        {
            // Authenticate

            mWaitingForAuth = true;
            GoogleGameslink.GetComponent<Text>().text = "Authenticating...";
            BtnLeaderBoard.SetActive(false);
            Social.localUser.Authenticate((bool success) =>
                {
                    mWaitingForAuth = false;
                    if (success)
                    {
                        BtnLeaderBoard.SetActive(true);
                        GoogleGameslink.GetComponent<Text>().text = "Sign Out   ";
                        mStatusText = "Welcome " + Social.localUser.userName;
                    }
                    else
                    {
                        BtnLeaderBoard.SetActive(false);
                        GoogleGameslink.GetComponent<Text>().text = "Google Games ";
                        mStatusText = "Authentication failed.";
                    }
                });
        }
        else
        {
            // Sign out!
            BtnLeaderBoard.SetActive(false);
            GoogleGameslink.GetComponent<Text>().text = "Google Games ";
            ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
        }

        if (Social.localUser.authenticated)
        {
            BtnLeaderBoard.SetActive(true);
            GoogleGameslink.GetComponent<Text>().text = "Sign Out   ";
        }
    }

    void Start()
    {
        if (Social.localUser.authenticated)
        {
            BtnLeaderBoard.SetActive(true);
            GoogleGameslink.GetComponent<Text>().text = "Sign Out   ";
        }
        PlayGamesPlatform.Activate();
        BestScoreTextDown.text = PlayerPrefs.GetInt("BestScore").ToString();
        SoundSlider.value = PlayerPrefs.GetFloat("Sound");
        AudioListener.volume = PlayerPrefs.GetFloat("Sound");
        changeMaxValue();
        // BestScoreText.text ="Рекорд:"+ PlayerPrefs.GetInt("BestScore");
        Advertisement.Initialize("3166346", false);
    }

    public void EventShowSettings()
    {
        SettingsUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void EventShowShop()
    {
        ShopUIlink.SetActive(true);
        MenuUI.SetActive(false);
    }
    public void EventShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Удачный просмотр рекламы.");//Можно добавить игроку монет

                break;
            case ShowResult.Skipped:
                Debug.Log("Реклама пропущена.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Ошибка просмотра рекламы.");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        MainCamera.GetComponent<Camera>().backgroundColor = new Color(
            Mathf.PingPong((Time.time + 160f) * 0.6f, 100) / 100,
            Mathf.PingPong((Time.time + 115f) * 0.6f, 100) / 100,
            Mathf.PingPong((Time.time + 85f) * 0.6f, 100) / 100);
        BestScoreText.color = new Color(
            Mathf.PingPong((Time.time + 2f) * speedR, 100) / 100,
            Mathf.PingPong(Time.time * speedG, 100) / 100,
            Mathf.PingPong(Time.time * speedB, 100) / 100);
        BestScoreTextDown.color = new Color(
            Mathf.PingPong((Time.time + 2f) * speedR, 100) / 100,
            Mathf.PingPong(Time.time * speedG, 100) / 100,
            Mathf.PingPong(Time.time * speedB, 100) / 100);
    }
    void changeMaxValue()
    {
        speedR = Random.Range(20, 50) * speedMultiple;
        speedG = Random.Range(20, 50) * speedMultiple;
        speedB = Random.Range(20, 50) * speedMultiple;
    }
    //Ивенты для главного меню
    public void EventShowStart()
    {
        StartUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void EventAbout()
    {
        About.gameObject.SetActive(true);
    }
    public void EventBtnOK()
    {
        About.gameObject.SetActive(false);
    }
    public void EventExit()
    {
        Application.Quit();
    }
    public void EventShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}
