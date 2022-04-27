using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager S;
    private void Awake()
    {
        S = this;
    }



    public float seconds;


    public Text TimerText;
    public Text DialogText;
    public AudioSource SoundOutOfTime;

    public GameObject Selector;
    public GameObject ButtonStart;
    public GameObject ButtonCancel;
    public GameObject ButtonShutDown;
    public GameObject ButtonAdd;
    public GameObject ButtonMinus;
    public GameObject ButtonSettings;
    public GameObject ButtonSkip;


    bool isStarted = false;
    bool isOutOfTime = false;

    // Swpie Detection
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    private string swipeDirection = "";

    public float swpieRange;
    public float tapRange;


    // Start is called before the first frame update
    void Start()
    {   
        
        ButtonAdd.SetActive(true);
        ButtonMinus.SetActive(true);
        ButtonStart.SetActive(true);
        ButtonSettings.SetActive(true);
        ButtonCancel.SetActive(false);
        ButtonShutDown.SetActive(false);
        RefreshDialogText("Quick Select");
    }

    // Update is called once per frame
    void Update()
    {
        SetButtonSkip();
        RefreshTimerText(TimeToString(seconds));
        if (isStarted)
        {
            ButtonStart.SetActive(false);
            ButtonCancel.SetActive(true);
            ButtonAdd.SetActive(false);
            ButtonMinus.SetActive(false);
            ButtonSettings.SetActive(false);
            Selector.SetActive(false);
            if (seconds >= 0)
            {
                seconds -= Time.deltaTime;
                RefreshTimerText(TimeToString(seconds));
            }
            else
            {
                ButtonCancel.SetActive(false);
                ButtonShutDown.SetActive(true);
                RefreshTimerText(TimeToString(0f));
                isOutOfTime = true;
                if (!SoundOutOfTime.isPlaying)
                {
                    SoundOutOfTime.Play();
                    if (SoundOutOfTime.volume <= 1.0f)
                    {
                        // volume up
                        SoundOutOfTime.volume += 0.1f; 
                    }
                }
            }
        }
    }

    public void SetTimer(float s)
    {
        seconds = s;
    }

    public void AddTimer()
    {
        seconds += 900;
    }

    public void MinusTimer()
    {
        if (seconds >= 900)
        {
            seconds -= 900;
        }
    }

    public void StartTimer()
    {
        isStarted = true;
        RefreshDialogText("Have a good night!");
    }

    public void EndTimer()
    {
        isOutOfTime = true;
    }

    public void CancelTimer()
    {
        isStarted = false;
        seconds = 28800f;


        ButtonStart.SetActive(true);
        Selector.SetActive(true);
        ButtonAdd.SetActive(true);
        ButtonMinus.SetActive(true);
        ButtonSettings.SetActive(true);
        ButtonShutDown.SetActive(false);
        ButtonCancel.SetActive(false);
        RefreshDialogText("Quick Select");
    }

    private void RefreshTimerText(string str)
    {
        TimerText.text = str;
    }

    private void RefreshDialogText(string str)
    {
        DialogText.text = str;
    }

    public string TimeToString(float setTimer)
    {
        int hour = (int)setTimer / 3600;
        int minute = ((int)setTimer - hour * 3600) / 60;
        int second = (int)setTimer - hour * 3600 - minute * 60;
        int millisecond = (int)((setTimer - (int)setTimer) * 1000);
        string outputtime = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        return outputtime;
    }

    public void SetButtonSkip()
    {
        if (PlayerPrefs.GetInt("isdeveloper", 0) == 1)
        {
            ButtonSkip.SetActive(true);
        }
        else
        {
            ButtonSkip.SetActive(false);
        }
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swpieRange)
                {
                    // Left
                    stopTouch = true;
                    swipeDirection = "left";
                }
                else if (Distance.x > swpieRange)
                {
                    // Right
                    stopTouch = true;
                    swipeDirection = "right";
                }
                else if (Distance.y > swpieRange)
                {
                    // Up
                    stopTouch = true;
                    swipeDirection = "up";
                }
                else if (Distance.y < -swpieRange)
                {
                    // Down
                    stopTouch = true;
                    swipeDirection = "down";
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                // Tap, no response
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        yield return null;
    }
}
