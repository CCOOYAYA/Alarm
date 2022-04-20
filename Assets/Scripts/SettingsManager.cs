using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager S;
    private void Awake()
    {
        S = this;
    }


    public GameObject mask;
    public GameObject dialog_confirm;
    public GameObject text_developer;
    public Toggle tog_12h;
    public Toggle tog_hardlevels;

    private int input = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isdeveloper", 0 ) == 1)
        {
            text_developer.SetActive(true);
        }
        else
        {
            text_developer.SetActive(false);
        }

        if (PlayerPrefs.GetInt("is12hourclock", 0) == 1)
        {
            tog_12h.isOn = true;
        }
        else
        {
            tog_12h.isOn = false;
        }

        if (PlayerPrefs.GetInt("enablehardlevels", 0) == 1)
        {
            tog_hardlevels.isOn = true;
        }
        else
        {
            tog_hardlevels.isOn = false;
        }

        mask.SetActive(false);
        dialog_confirm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActiveDeveloperMode();
    }

    
    public void ActiveConfirmPage(bool flag)
    {
        if (flag == true)
        {
            mask.SetActive(true);
            dialog_confirm.SetActive(true);
        }
        else
        {
            mask.SetActive(false);
            dialog_confirm.SetActive(false);
        }
    }


    public void SetClockSettings(bool tog)
    {
        if (tog)
        {
            PlayerPrefs.SetInt("is12hourclock", 1);
        }
        else
        {
            PlayerPrefs.SetInt("is12hourclock", 0);
        }
    }

    public void SetEnableHardLevels(bool tog)
    {
        if (tog)
        {
            PlayerPrefs.SetInt("enablehardlevels", 1);
        }
        else
        {
            PlayerPrefs.SetInt("enablehardlevels", 0);
        }
    }








    public void ActiveDeveloperMode()
    {

        if (Input.touchCount >= 5)
        {
            text_developer.SetActive(true);
            PlayerPrefs.SetInt("isdeveloper", 1);
        }

        if (Input.GetKeyDown("d"))
        {
            input++;
        }

        if (input >= 5){ 
            text_developer.SetActive(true);
            PlayerPrefs.SetInt("isdeveloper", 1);
        }
    }
}
