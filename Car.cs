using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    private SpriteRenderer _mySprite;
    private Transform _myTransform;
    private GameObject ES;
    public GameObject gos;
    public GameObject guiLink;
    public AudioClip moveSound;
    public AudioClip gameOverSound;
    public GameObject BGlink;
    public GameObject MainCamera;
    private int Nposition = 0;

    private void OnTriggerStay2D(Collider2D collision)//Машина сталкивается с врагом(на самом деле с любой коллизией)
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;//Отключить тригер при столкновении
        //print("GameOver");
        ES.GetComponent<EnemySystem>().pause = true;
        gos.SetActive(true);//Включает экран смерти GameOverScreen
        SoundManager.instance.PlaySingle(gameOverSound);
        this.GetComponent<Animator>().Play("CarDeath");
        guiLink.GetComponent<UIScript>().ScoreResult();//Выводим количество очков в GameOverScreen


    }
    void Awake()
    {
        _mySprite = this.GetComponent<SpriteRenderer>();
        _myTransform = this.GetComponent<Transform>();
        SetSkin();
        SetBG();
        gos.SetActive(false);
        ES = GameObject.Find("EnemySpawner");

    }
    void Start()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;//Включить тригер при загрузке
    }
    public void MoveLeft()
    {

        if (ES.GetComponent<EnemySystem>().pause == false && Nposition == 0)
        {
            Nposition = 1;
            this.transform.position = new Vector2(-0.225f, -0.636f);
            SoundManager.instance.PlayNoSingle(moveSound);
        }
    }

    public void MoveRight()
    {

        if (ES.GetComponent<EnemySystem>().pause == false && Nposition == 1)
        {
            Nposition = 0;
            this.transform.position = new Vector2(0.225f, -0.636f);
            SoundManager.instance.PlayNoSingle(moveSound);
        }
    }

    void SetSkin()
    {
        if (PlayerPrefs.GetString("Car") == "Car4")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/Car4");
        }
        if (PlayerPrefs.GetString("Car") == "Car5")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/Car5");
        }
        if (PlayerPrefs.GetString("Car") == "CarDefault")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/CarOrig");
        }

        if (PlayerPrefs.GetString("Car") == "CarTwo")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/CarTwo");
        }
        if (PlayerPrefs.GetString("Car") == "CarTank")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/CarTank");
        }
        if (PlayerPrefs.GetString("Car") == "CarThree")
        {
            _mySprite.sprite = Resources.Load<Sprite>("Image/CarThree");
        }
    }

    void SetBG()
    {

        if (PlayerPrefs.GetString("BG") == "BGDefault")
        {
            BGlink.GetComponent<ScriptBG>().goBackroundSet(0);
            MainCamera.GetComponent<Camera>().backgroundColor = new Color(0.9843138f, 0.7137255f, 0.6078432f, 1);
        }
        if (PlayerPrefs.GetString("BG") == "BGGreen")
        {
            BGlink.GetComponent<ScriptBG>().goBackroundSet(1);
            MainCamera.GetComponent<Camera>().backgroundColor = new Color(0.4666667f, 0.627451f, 0.5647059f, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            MoveRight();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

    }
}
