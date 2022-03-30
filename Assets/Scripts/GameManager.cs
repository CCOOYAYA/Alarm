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
    public AudioSource sfx_start;
    public AudioSource sfx_win;
    public AudioSource sfx_lose;
    public AudioSource sfx_oot;

    public GameObject dialog_hint;
    public GameObject dialog_win;
    public GameObject dialog_lose;
    public GameObject masklayer;

    private float UI_Alpha = 0f;
    // The speed of UI fade out
    private float alphaSpeed = 0.4f;
    private CanvasGroup canvasGroup;

    private bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        dialog_hint.SetActive(true);
        canvasGroup = dialog_hint.GetComponent<CanvasGroup>();
        dialog_win.SetActive(false);
        dialog_lose.SetActive(false);
        masklayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HintFadeOut();
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

    private void HintFadeOut()
    {
        if (canvasGroup == null)
        {
            return;
        }

        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
        }
    }

    public void HintOff()
    {
        dialog_hint.SetActive(false);
        if (isStarted == false && !sfx_start.isPlaying)
        {
            sfx_start.Play();
            isStarted = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        yield return null;
    }
}

