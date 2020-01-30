using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
public class ItemIds : MonoBehaviour
{
    void Awake()
    {

    }

    void Start()
    {

    }

    public static bool itemIsBuy(string id)
    {
        bool Buy;
        if (PlayerPrefs.HasKey(id))
        {
            if (PlayerPrefs.GetInt(id) == 1)
            {
                Buy = true;
            }
            else
            {
                Buy = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt(id, 0);
            Buy = false;
            PlayerPrefs.Save();
        }
        return Buy;
    }
    public void buyOrSet(string id)
    {
        if (itemIsBuy(id))
        {
            PlayerPrefs.SetString("Car", id);
            //Debug.Log("Машина установлена как "+ id);
            PlayerPrefs.Save();
        }
        else
        {
            int PlusCoin = PlayerPrefs.GetInt("PlusCoin");

            if (PlusCoin >= carPrice(id))
            {
                PlayerPrefs.SetString("Car", id);
                //Debug.Log("Машина установлена как " + id);
                SpentCoinGoogle(carPrice(id));
                PlayerPrefs.SetInt("PlusCoin", PlusCoin - carPrice(id));
                PlayerPrefs.SetInt(id, 1);
                PlayerPrefs.Save();
                //Debug.Log("Покупка "+id+" за сумму "+carPrice(id));
            }
            else
            {
                Debug.Log("Не хватает средств");
            }
        }
    }
    public void SpentCoinGoogle(int coin)
    {
        if (Social.localUser.authenticated)
            GooglePlayGames.PlayGamesPlatform.Instance.Events.IncrementEvent(GPGSIds.event_spent_pluscoins, (uint)coin);
    }
    public void buyOrSetBG(string id)
    {
        if (itemIsBuy(id))
        {
            PlayerPrefs.SetString("BG", id);
            //Debug.Log("Фон установлен как " + id);
            PlayerPrefs.Save();
        }
        else
        {
            int PlusCoin = PlayerPrefs.GetInt("PlusCoin");

            if (PlusCoin >= BGPrice(id))/////////////////////////
            {
                PlayerPrefs.SetString("BG", id);
                //Debug.Log("Фон установлен как " + id);
                SpentCoinGoogle(BGPrice(id));
                PlayerPrefs.SetInt("PlusCoin", PlusCoin - BGPrice(id));
                PlayerPrefs.SetInt(id, 1);
                PlayerPrefs.Save();
                //Debug.Log("Покупка " + id + " за сумму " + BGPrice(id));
            }
            else
            {
                Debug.Log("Не хватает средств");
            }
        }
    }
    public static string CoinMyId(string id)
    {
        string TextResponse = "";
        switch (id)
        {
            case "Car4":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "Car5":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "CarDefault":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "CarTwo":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "CarTank":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "CarThree":
                TextResponse = (PlayerPrefs.GetString("Car") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : carPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "BGDefault":
                TextResponse = (PlayerPrefs.GetString("BG") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : BGPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            case "BGGreen":
                TextResponse = (PlayerPrefs.GetString("BG") != id) ? TextResponse = itemIsBuy(id) ? LocalizationManager.Localize("Menu.Set") : BGPrice(id).ToString() : LocalizationManager.Localize("Menu.Installed");
                break;
            default:
                TextResponse = "NoN";
                break;
        }
        return (TextResponse);
    }
    public static int carPrice(string id)
    {
        int price = 0;
        switch (id)
        {
            case "Car4":
                price = 10000;
                break;
            case "Car5":
                price = 10000;
                break;
            case "CarDefault":
                price = 0;
                break;
            case "CarTwo":
                price = 500;
                break;
            case "CarTank":
                price = 2500;
                break;
            case "CarThree":
                price = 10000;
                break;
            default:
                price = 999999;
                break;
        }
        return (price);
    }

    public static int BGPrice(string id)
    {
        int price = 0;
        switch (id)
        {
            case "BGDefault":
                price = 0;
                break;
            case "BGGreen":
                price = 10000;
                break;
            default:
                price = 999999;
                break;
        }
        return (price);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
