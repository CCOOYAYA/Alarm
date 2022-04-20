using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimer10Hours()
    {
        UIManager.S.SetTimer(36000f);
    }

    public void SetTimer8Hours()
    {
        UIManager.S.SetTimer(28800f);
    }

    public void SetTimer6Hours()
    {
        UIManager.S.SetTimer(21600f);
    }

    public void Quit()
    {
        // Quit
        Application.Quit();
    }

    public void JumpToSharePage()
    {
        // Jump to share page
        SceneManager.LoadScene(5);
    }

    public void TryAgain()
    {
        // Reloda Current Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void JumpToMainPage()
    {
        // Jump to main page
        SceneManager.LoadScene(0);
    }

    public void JumpToSettingsPage()
    {
        // Jump to settings page
        SceneManager.LoadScene(6);
    }

    public void DeleteData()
    {
        SettingsManager.S.ActiveConfirmPage(true);
    }

    public void ConfirmDeleteData()
    {
        PlayerPrefs.DeleteKey("date");
        PlayerPrefs.DeleteKey("finishattime");
        PlayerPrefs.DeleteKey("streak");
        PlayerPrefs.Save();
        SettingsManager.S.ActiveConfirmPage(false);
    }

    public void AbandonDeleteData()
    {
        SettingsManager.S.ActiveConfirmPage(false);
    }











}
