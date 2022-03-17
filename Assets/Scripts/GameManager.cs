using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    private void Awake()
    {
        S = this;
    }

    public Text staminaText;
    public AudioSource sfx_win;
    public AudioSource sfx_lose;
    public AudioSource sfx_oot;

    public GameObject dialog_win;
    public GameObject dialog_lose;
    public GameObject masklayer;

    // Start is called before the first frame update
    void Start()
    {
        dialog_win.SetActive(false);
        dialog_lose.SetActive(false);
        masklayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshStaminText(int stamina)
    {
        staminaText.text = "Stamina Left: " + stamina.ToString();
    }

    public void Win(int activetime)
    {
        if (activetime == 1)
        {
            masklayer.SetActive(true);
            dialog_win.SetActive(true);
            StopAllCoroutines();
            int count = 0;
            if (!sfx_win.isPlaying && count == 0)
            {
                sfx_win.Play();
                count++;
            }
        }
    }

    public void Lose(int activetime)
    {
        if (activetime == 1)
        {
            masklayer.SetActive(true);
            dialog_lose.SetActive(true);
            StopAllCoroutines();
            int count = 0;
            if (!sfx_lose.isPlaying && count == 0)
            {
                sfx_lose.Play();
                count++;
            }        
            StartCoroutine("Wait");
            if (!sfx_oot.isPlaying)
            {
                sfx_oot.Play();
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        yield return null;
    }
}

