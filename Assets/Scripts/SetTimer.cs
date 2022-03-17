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
        // �˳�Ӧ��
        Application.Quit();
    }

    public void TryAgain()
    {
        // ���ص�ǰ�ؿ�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
