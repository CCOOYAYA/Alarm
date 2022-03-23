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

    public Text stepText;
    public Text hintText;
    public AudioSource sfx_win;
    public AudioSource sfx_lose;
    public AudioSource sfx_oot;

    public GameObject dialog_win;
    public GameObject dialog_lose;
    public GameObject masklayer;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HintFadeOut");
        dialog_win.SetActive(false);
        dialog_lose.SetActive(false);
        masklayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshStepText(int steps)
    {
        stepText.text = "Step Count: " + steps.ToString();
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

    IEnumerator HintFadeOut()
    {
        Color color = hintText.color;
        color.a = 1;
        hintText.color = color;
        yield return new WaitForSeconds(1);

        float fadeOutTime = 1;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / fadeOutTime;
            color.a = (1 - percent);
            hintText.color = color;
            yield return null;
        }
    }
}

