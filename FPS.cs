using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public int _frameRate = 60;
    GUIStyle style = new GUIStyle();
    int accumulator = 0;
    int accumulatorS = 0;
    int accumulatorDelta = 0;
    int counter = 0;
    public static int score = 0;
    float timer = 0f;
    private bool deltatime = true;
    private GameObject ES;
    public Text ScoreTextLink;
    private void Awake()
    {
        ES = GameObject.Find("EnemySpawner");
    }
    void Start()
    {
        score = 0;
        style.normal.textColor = Color.white;
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;

        //QualitySettings.vSyncCount = 0;//

    }

    void OnGUI()
    {

        //  GUI.Label(new Rect(10, 10, 100, 34), "FPS: " + counter, style);
        // GUI.Label(new Rect(10, 44, 100, 34), "Etick Number: " + ES.GetComponent<EnemySystem>().EtickNumber, style);
        // GUI.Label(new Rect(10, 78, 100, 34), "Score: " + score, style);
        // GUI.Label(new Rect(10, 112, 100, 34), "ScorePerSecond: " + accumulatorS, style);
        // GUI.Label(new Rect(10, 148, 100, 34), "Best Score: " + PlayerPrefs.GetInt("BestScore"), style);
        // GUI.Label(new Rect(10, 182, 100, 34), "PlusCoin: " + PlayerPrefs.GetInt("PlusCoin"), style);
        //  GUI.Label(new Rect(10, 182+34, 100, 34), "Pause: " + ES.GetComponent<EnemySystem>().pause, style);
    }

    void Update()
    {
        ScoreTextLink.text = score.ToString();
        if (deltatime == true)
        {
            accumulatorDelta = score;
            deltatime = false;
        }
        if (_frameRate != Application.targetFrameRate)//
            Application.targetFrameRate = _frameRate;//

        accumulator++;

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            counter = accumulator;
            accumulator = 0;
            accumulatorS = score - accumulatorDelta;
            deltatime = true;
        }
    }
}