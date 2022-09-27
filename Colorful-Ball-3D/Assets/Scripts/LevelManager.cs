using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelIndex") == false)
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        StartCoroutine("LoadingBar");
        LevelControl();
    }
    public void LevelControl()
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(level);
    }
    public IEnumerator LoadingBar()
    {
        while (true)
        {
            print("calıstı");
            loadingText.text = "Loading".ToString();
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading.".ToString();
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading..".ToString();
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading...".ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
