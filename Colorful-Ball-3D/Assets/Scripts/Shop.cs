using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UIManager uimanager;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite YellowImage;
    public Sprite GreenImage;

    public GameObject Effect1;
    public GameObject Effect2;
    public GameObject Effect3;
    public GameObject Effect4;

    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Lock4;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("effectselect") == false)
            PlayerPrefs.SetInt("effectselect", 0);

        if (PlayerPrefs.GetInt("effectselect") == 0)
            Effect1Open();
        else if (PlayerPrefs.GetInt("effectselect") == 1)
            Effect2Open();
        else if (PlayerPrefs.GetInt("effectselect") == 2)
            Effect3Open();
        else if (PlayerPrefs.GetInt("effectselect") == 3)
            Effect4Open();


        if (PlayerPrefs.HasKey("lock2control") == false)
            PlayerPrefs.SetInt("lock2control", 0);

        if (PlayerPrefs.HasKey("lock3control") == false)
            PlayerPrefs.SetInt("lock3control", 0);

        if (PlayerPrefs.HasKey("lock4control") == false)
            PlayerPrefs.SetInt("lock4control", 0);


        if (PlayerPrefs.GetInt("lock2control") == 1)
            Lock2.SetActive(false); 

        if (PlayerPrefs.GetInt("lock3control") == 1)
            Lock3.SetActive(false);

        if (PlayerPrefs.GetInt("lock4control") == 1)
            Lock4.SetActive(false);
    }

    public void Effect1Open()
    {
        particle1.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);

        Effect1.GetComponent<Image>().sprite = GreenImage;
        Effect2.GetComponent<Image>().sprite = YellowImage;
        Effect3.GetComponent<Image>().sprite = YellowImage;
        Effect4.GetComponent<Image>().sprite = YellowImage;

        PlayerPrefs.SetInt("effectselect", 0);
    }
    public void Effect2Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);

        Effect1.GetComponent<Image>().sprite = YellowImage;
        Effect2.GetComponent<Image>().sprite = GreenImage;
        Effect3.GetComponent<Image>().sprite = YellowImage;
        Effect4.GetComponent<Image>().sprite = YellowImage;

        PlayerPrefs.SetInt("effectselect", 1);
    }
    public void Effect3Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);

        Effect1.GetComponent<Image>().sprite = YellowImage;
        Effect2.GetComponent<Image>().sprite = YellowImage;
        Effect3.GetComponent<Image>().sprite = GreenImage;
        Effect4.GetComponent<Image>().sprite = YellowImage;
        PlayerPrefs.SetInt("effectselect", 2);
    }
    public void Effect4Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);

        Effect1.GetComponent<Image>().sprite = YellowImage;
        Effect2.GetComponent<Image>().sprite = YellowImage;
        Effect3.GetComponent<Image>().sprite = YellowImage;
        Effect4.GetComponent<Image>().sprite = GreenImage;
        PlayerPrefs.SetInt("effectselect", 3);
    }

    public void FailedSituation()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);
    }

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");

        if (money >= 2000)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("moneyy",money -2500);
            PlayerPrefs.SetInt("lock2control", 1);
            Effect2Open();
            uimanager.CoinTextUpdate();
        }
    }
    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");

        if (money >= 5000)
        {
            Lock3.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 5000);
            PlayerPrefs.SetInt("lock3control", 1);
            Effect3Open();
            uimanager.CoinTextUpdate();
        }
    }
    public void Lock4Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");

        if (money >= 7500)
        {
            Lock4.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 7500);
            PlayerPrefs.SetInt("lock4control", 1);
            Effect4Open();
            uimanager.CoinTextUpdate();
        }
    }
}
