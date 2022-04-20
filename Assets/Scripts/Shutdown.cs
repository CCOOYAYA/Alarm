using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shutdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpToRandomLevel()
    {
        if (PlayerPrefs.GetInt("enablehardlevels", 1) == 1)
        {
            int p = Random.Range(1, 5);
            SceneManager.LoadScene(p);
        }
        else
        {
            int p = Random.Range(1, 4);
            SceneManager.LoadScene(p);
        }
        
    }
}
