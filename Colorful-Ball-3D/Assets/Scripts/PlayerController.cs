using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Shop shop;

    public CameraShake camerashake;
    public UIManager uimanager;
    public SoundManager soundmanager;

    private Rigidbody rb;

    public GameObject cam;
    public GameObject vectorBack;
    public GameObject vectorForward;

    public GameObject hand_image;
    public GameObject touch_to_move;

    private Touch touch;
    [Range(20, 55)]
    public int speedModifier;
    [Range(10, 25)]
    public int forwardSpeed;

    public GameObject[] Fructures;
    public bool isObstaclesHit;

    public bool firstTouchControl;

    public bool isGameFinished;

    private void Awake()
    {
        Time.timeScale = 1f;
        Variables.firsttouch = 0;
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        if (Variables.firsttouch == 1 && !isGameFinished)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0 && !isGameFinished)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (!firstTouchControl)
                    {
                        Variables.firsttouch = 1;
                        uimanager.FirstTouchCloser();
                        touch_to_move.SetActive(false);
                        firstTouchControl = true;
                    }
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                            transform.position.y,
                                            touch.deltaPosition.y * speedModifier * Time.deltaTime);
                    if (!firstTouchControl)
                    {
                        Variables.firsttouch = 1;
                        uimanager.FirstTouchCloser();
                        touch_to_move.SetActive(false);
                        firstTouchControl = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles") && !isObstaclesHit)
        {
            uimanager.isGameFailed = true;
            isGameFinished = true;
            isObstaclesHit = true;
            soundmanager.BlowUpSound();
            if (PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
                Debug.Log("vib");
            }
            else if(PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("no vibration");
            }
            shop.FailedSituation();
            uimanager.RestartScene();
            uimanager.WhiteEffectCall();
            camerashake.CameraShakesCall();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in Fructures)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else if (hit.gameObject.CompareTag("Untagged") && !isObstaclesHit)
        {
            soundmanager.HitSound();
        }
    }
}




