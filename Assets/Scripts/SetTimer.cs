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
        // 退出应用
        Application.Quit();
    }

    public void TryAgain()
    {
        // 重载当前关卡
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
