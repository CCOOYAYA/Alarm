using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Utility U;
    private void Awake()
    {
        U = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // return current time in 24hour clock
    public string GetCurrentTime24h()
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
        string time = string.Format("{0:D2}:{1:D2}", hour, minute);
        return time;
    }

    // return current time in 12hour clock
    public string GetCurrentTime12h()
    {
        int hour = System.DateTime.Now.Hour;
        bool isafternoon = false;
        if (hour > 12 && hour < 24)
        {
            hour -= 12;
            isafternoon = true;
        }
        string minute;
        if (System.DateTime.Now.Minute <= 9 && System.DateTime.Now.Minute >= 0)
        {
            minute = "0" + System.DateTime.Now.Minute.ToString();
        }
        else
        {
            minute = System.DateTime.Now.Minute.ToString();
        }
        string flag = "AM";
        if (isafternoon)
        {
            flag = "PM";
        }
        string time = string.Format("{0:D2}:{1:D2}{2:D2}", hour.ToString(), minute, flag);
        return time;
    }








}
