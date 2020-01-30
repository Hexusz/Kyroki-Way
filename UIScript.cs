using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.Analytics;
public class UIScript : MonoBehaviour
{
    public Text ScoreTextLink;
    public GameObject BtnAds;
    public GameObject AdImgLink;
    private GameObject ES;
    int PCoin;
    int BestScr;

    void Awake()
    {
        ES = GameObject.Find("EnemySpawner");

    }
    void Start()
    {
        Advertisement.Initialize("3166346", false);

    }
    public void EventPauseBtn()
    {
        if (ES.GetComponent<EnemySystem>().pause == true)
            ES.GetComponent<EnemySystem>().pause = false;
        else
            ES.GetComponent<EnemySystem>().pause = true;
    }
    public void EventGoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
                //Debug.Log("Удачный просмотр рекламы.");
                ReceivedCoinGoogle(FPS.score);
                ScoreTextLink.text = "   " + FPS.score * 2;
                AddPlusCoin(FPS.score);
                BtnAds.SetActive(false);
                AdImgLink.SetActive(false);
                AnalyticsEvent.AdStart(true);
                break;
            case ShowResult.Skipped:
                AnalyticsEvent.AdSkip(true);
                //Debug.Log("Реклама пропущена.");
                break;
            case ShowResult.Failed:

                AnalyticsEvent.Custom("AdFail", new Dictionary<string, object>
    {
        { "secret_id", true },
        { "time_elapsed", Time.timeSinceLevelLoad }
    });

                //Debug.LogError("Ошибка просмотра рекламы.");
                break;
        }
    }

    public void AddPlusCoin(int col)
    {
        if (PlayerPrefs.HasKey("PlusCoin"))
        {
            PCoin = PlayerPrefs.GetInt("PlusCoin");

            PlayerPrefs.SetInt("PlusCoin", PCoin + col);
            //Сохраним внесенные изменения 
            PlayerPrefs.Save();
            //Debug.Log("Добавлено "+ col+" PlusCoin'ов");
        }
    }
    public void BestScore(int col)
    {

        if (PlayerPrefs.HasKey("BestScore"))
        {
            BestScr = PlayerPrefs.GetInt("BestScore");
            if (BestScr < col)
            {
                PlayerPrefs.SetInt("BestScore", col);
                PlayerPrefs.Save();
                //Debug.Log("Новый рекорд: "+ col);

            }
        }
    }
    public void EventReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReceivedCoinGoogle(int coin)
    {
        if (Social.localUser.authenticated)
            GooglePlayGames.PlayGamesPlatform.Instance.Events.IncrementEvent(GPGSIds.event_received_pluscoins, (uint)coin);
    }
    public void ScoreResult()
    {

        ReceivedCoinGoogle(FPS.score);

        ScoreTextLink.text = "   " + FPS.score;
        AddPlusCoin(FPS.score);//Добавляем очки
        BestScore(FPS.score);//Проверяем на лучший результат

        if (Social.localUser.authenticated)
            Social.ReportScore(FPS.score, "CgkIkqKzvIoWEAIQAQ", (bool success) =>
            {
                if (success)
                    Debug.Log("Данные отправлены");
                else
                    Debug.Log("Ошибка отправки");
            });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
