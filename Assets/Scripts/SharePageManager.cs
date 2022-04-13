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

    public GameObject dialog_share;

    // Start is called before the first frame update
    void Start()
    {
        dialog_share.SetActive(false);
        GetSteps();
        GetStreak();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentTime();
    }


    public string GetCurrentTime()
    {
        string hour = System.DateTime.Now.Hour.ToString();
        string minute;
        if (System.DateTime.Now.Minute <= 9 && System.DateTime.Now.Minute >= 0)
        {
            minute = "0" + System.DateTime.Now.Minute.ToString();
        }
        else
        {
            minute = System.DateTime.Now.Minute.ToString();
        }
        return time.text = string.Format("{0:D2}:{1:D2}", hour, minute);
    }


    public void GetSteps()
    {
        steps.text = PlayerController.steps.ToString();
    }

    public string GetStreak()
    {
        return streak.text = PlayerPrefs.GetInt("streak", 0).ToString();
    }

    public void ActiveDialogShare()
    {
        dialog_share.SetActive(true);
    }
}
