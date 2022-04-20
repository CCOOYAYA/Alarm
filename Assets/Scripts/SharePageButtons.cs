using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharePageButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Quit()
    {
        Application.Quit();
    }

    public void Share()
    {
        SharePageManager.S.ActiveDialogShare();  
        UnityEngine.GUIUtility.systemCopyBuffer = "Sleeper finished at " + SharePageManager.S.GetFinishAtTime() + 
            ". Total steps used: " + PlayerController.steps.ToString() + ". I have been using Sleeper for " + 
            SharePageManager.S.GetStreak() + " day(s).";
    }
}
