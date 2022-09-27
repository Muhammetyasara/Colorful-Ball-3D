using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SoundManager soundmanager;
    public PlayerController playercontroller;

    public Image whiteeffectimage;
    public bool imageControl;
    public int effectControl = 0;

    public Animator LayoutAnimator;

    public Text coinText;

    public GameObject Player;
    public GameObject finishLine;

    public GameObject noAds;
    public GameObject noAdsOpenImg;
    public GameObject cancelButton;
    public GameObject storage;
    public GameObject handImage;

    public GameObject layout_Background;
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap_Button;
    public GameObject information_On;
    public GameObject information;

    public GameObject restart_button;
    public bool isGameFailed;


    public GameObject privacy_Policy;
    public GameObject term_Of_Use;

    public GameObject finishScreen;
    public GameObject backGround;
    public GameObject completed;
    public GameObject completedEffect;
    public GameObject coin;
    public GameObject coin_text;
    public GameObject radialShine;

    public GameObject nextLevel;

    public bool radialShineEffect;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);

        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        CoinTextUpdate();
    }
    private void Update()
    {
        if (radialShineEffect == true)
        {
            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        }
    }

    public void InformationOn()
    {
        information.SetActive(true);
    }
    public void PrivacyPolicy()
    {
        //Application.OpenURL(privacy policy gelecek!!!!!);
    }
    public void TermOfUse()
    {
        //Application.OpenURL(term of use gelecek!!!!!);
    }

    public void SettingsOpen()
    {
        Variables.firsttouch = 0;
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_Off.SetActive(false);
            sound_On.SetActive(true);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_Off.SetActive(true);
            sound_On.SetActive(false);
            AudioListener.volume = 0;
        }
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_Off.SetActive(false);
            vibration_On.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    }
    public void SettingsClose()
    {
        Variables.firsttouch = 0;
        settings_Close.SetActive(false);
        settings_Open.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_out");
    }

    public void SoundOn()
    {
        Variables.firsttouch = 0;
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void SoundOff()
    {
        Variables.firsttouch = 0;
        sound_Off.SetActive(false);
        sound_On.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        Variables.firsttouch = 0;
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);

    }
    public void Vibration_Off()
    {
        Variables.firsttouch = 0;
        vibration_Off.SetActive(false);
        vibration_On.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }
    public void FirstTouchCloser()
    {
        layout_Background.SetActive(false);
        settings_Close.SetActive(false);
        settings_Open.SetActive(false);
        handImage.SetActive(false);
        noAds.SetActive(false);
        storage.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_Off.SetActive(false);
        vibration_On.SetActive(false);
        iap_Button.SetActive(false);
        information_On.SetActive(false);
        information.SetActive(false);
    }

    public void CoinTextUpdate()
    {
        coinText.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        playercontroller.isGameFinished = true;
        radialShineEffect = true;
        finishScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        soundmanager.CompletedSound();
        completed.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        completedEffect.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        backGround.SetActive(true);
        radialShine.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        coin.SetActive(true);
        coin_text.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        nextLevel.SetActive(true);
    }


    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.009f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectControl = 1;
            }
        }
        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.009f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                break;
            }
        }
    }

    public void WhiteEffectCall()
    {
        if (imageControl == false)
        {
            StartCoroutine(WhiteEffect());
            imageControl = true;
        }
    }
    public void RestartScene()
    {
        StartCoroutine(DelaySceneLoad());
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator DelaySceneLoad()
    {
        if (isGameFailed)
        {
            yield return new WaitForSeconds(0.5f);
            restart_button.SetActive(true);
        }
    }
    public void NoAds()
    {
        noAdsOpenImg.SetActive(true);
        cancelButton.SetActive(true);
    }
    public void CancelButton()
    {
        noAdsOpenImg.SetActive(false);
        cancelButton.SetActive(false);
    }
}