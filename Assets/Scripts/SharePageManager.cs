using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SharePageManager : MonoBehaviour
{
    public static SharePageManager S;
    private void Awake()
    {
        S = this;
    }

    public Text time;
    public Text steps;
    public Text streak;
    public Text text_days;

    public GameObject dialog_share;

    // Start is called before the first frame update
    void Start()
    {
        dialog_share.SetActive(false);
        RefreshTextDays();
        GetSteps();
        GetStreak();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshCurrentTime();
    }

    public void RefreshCurrentTime()
    {
        if (PlayerPrefs.GetInt("is12hourclock", 1) == 1)
        {
            time.text = Utility.U.GetCurrentTime12h();
        }
        else
        {
            time.text = Utility.U.GetCurrentTime24h();
        }
    }

    public void RefreshTextDays()
    {
        if (PlayerPrefs.GetInt("streak", 0) == 1)
        {
            text_days.text = "DAY";
        }
        else
        {
            text_days.text = "DAYS";
        }
    }

    public void GetSteps()
    {
        steps.text = PlayerController.steps.ToString();
    }

    public string GetStreak()
    {
        return streak.text = PlayerPrefs.GetInt("streak", 0).ToString();
    }

    public string GetFinishAtTime()
    {
        string time = PlayerPrefs.GetString("finishattime", "0:00");
        return time;
    }

    public void ActiveDialogShare()
    {
        dialog_share.SetActive(true);
    }
}
