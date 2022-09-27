using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public UIManager uimanager;
    public PlayerController playercontroller;

    private void Start()
    {
        CoinCalculator(0);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && gameObject.tag == "Finish")
        {
            uimanager.CoinTextUpdate();
            uimanager.FinishScreen();
            uimanager.NextScene();
            playercontroller.isGameFinished = true;
            CoinCalculator(100);
        }
    }
    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
            PlayerPrefs.SetInt("moneyy", 50000);
    }
}
