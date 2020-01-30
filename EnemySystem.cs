using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    public GameObject Enemy;
    private int Tick;
    public int TickToSpawn = 12;
    public bool pause = false;
    public List<GameObject> enemy_list;
    float offset = 0;
    private int Etick = 0;
    public int EtickNumber = 10;
    bool NewResult = false;
    private int BestScore;
    public AudioClip[] engineCarSound;
    public AudioClip startRaceSound;
    public AudioClip endlessEngine;
    public AudioClip StartEndlessEngine;
    public GameObject NewResultlink;

    public GameObject one;
    public GameObject two;
    public GameObject three;


    void Awake()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        Tick = TickToSpawn;
        pause = true;
    }

    void Start()
    {
        InvokeRepeating("EnemyTick", 0, 0.003f);

        //coroutine = GoRace();
        // StartCoroutine(coroutine);

        coroutine2 = SpeedChange();
        StartCoroutine(coroutine2);



    }
    private void ShowBest()
    {
        coroutine = GoRace();
        StartCoroutine(coroutine);
    }
    void EnemyTick()
    {
        Etick++;
        if (pause == false && Etick >= EtickNumber)
        {
            Etick = 0;
            foreach (GameObject obj in enemy_list)
            {
                obj.transform.Translate(new Vector2(0, -0.09f));//Дальность перемещения
            }



            Tick++;
            FPS.score++;
            if (FPS.score >= BestScore && NewResult == false)
            {
                NewResult = true;
                ShowBest();

            }
            if (Tick >= TickToSpawn)
            {
                Spawn();
                Tick = 0;
                //Speed = Speed - Speed / 100;
            }
        }
    }

    IEnumerator GoRace()
    {

        NewResultlink.SetActive(true);
        yield return new WaitForSeconds(2f);
        NewResultlink.SetActive(false);
        //pause = false;
    }

    IEnumerator SpeedChange()
    {
        //one.SetActive(true);
        //two.SetActive(true);
        //three.SetActive(true);
        pause = true;
        yield return new WaitForSeconds(0.25f);
        SoundManager.instance.PlaySingle(startRaceSound);
        yield return new WaitForSeconds(2.25f);
        three.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        three.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        two.SetActive(false);
        one.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        one.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        //yield return new WaitForSeconds(5);
        pause = false;

        if (pause == false && EtickNumber > 5)
        {
            SoundManager.instance.RandomizeSfx(engineCarSound);
            yield return new WaitForSeconds(6);
            EtickNumber -= 1;//Изменение скорости  
        }
        if (pause == false && EtickNumber > 5)
        {
            SoundManager.instance.RandomizeSfx(engineCarSound);
            yield return new WaitForSeconds(6);
            EtickNumber -= 1;//Изменение скорости  
        }
        if (pause == false && EtickNumber > 5)
        {
            SoundManager.instance.RandomizeSfx(engineCarSound);
            yield return new WaitForSeconds(6);
            EtickNumber -= 1;//Изменение скорости  
        }
        if (pause == false && EtickNumber > 5)
        {
            SoundManager.instance.RandomizeSfx(engineCarSound);
            yield return new WaitForSeconds(6);
            EtickNumber -= 1;//Изменение скорости  
        }
        if (pause == false && EtickNumber > 5)
        {
            SoundManager.instance.RandomizeSfx(engineCarSound);
            yield return new WaitForSeconds(6);
            EtickNumber -= 1;//Изменение скорости  
        }
        if (pause == false)
        {
            SoundManager.instance.PlaySingle(StartEndlessEngine);
            yield return new WaitForSeconds(3);

        }
        if (pause == false)
        {
            SoundManager.instance.PlaySingle(endlessEngine);
        }

    }

    void Spawn()
    {

        bool rand = Random.value > 0.5f;



        if (rand == true)
        {
            enemy_list.Add(Instantiate(Enemy, new Vector2(this.transform.position.x + 0.225f, this.transform.position.y), Quaternion.identity));
        }
        else
        {
            enemy_list.Add(Instantiate(Enemy, new Vector2(this.transform.position.x - 0.225f, this.transform.position.y), Quaternion.identity));
        }


        //Debug.Log(enemy_list.Count);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
