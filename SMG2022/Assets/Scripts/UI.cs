using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI : MonoBehaviour
{
    public bool Startbutton;
    public GameObject StartBtn;

    public GameObject FadePan;

    void Start()
    {
        SoundMgr.In.PlayLoopSound("6_MainMenuTheme");

        StartCoroutine(LoopTitle());
    }

    public void StartButtonClick()
    {
        StopCoroutine(LoopTitle());
        StartBtn.transform.DOMoveY(-625, 0.9f).SetEase(Ease.InBack);

        StartCoroutine(TitleWait());
    }
    public void TitleMove()
    {
        transform.DOMoveY(1500, 1.1f).SetEase(Ease.InBack);
    }

    IEnumerator LoopTitle()
    {
        float Count = 0;

        yield return null;

        while(true)
        {
            yield return null;
            this.gameObject.transform.position -= new Vector3(0, 12 * Time.deltaTime, 0);
            Count += 12 * Time.deltaTime;

            if (Count >= 30)
            {
                Debug.Log("asd");
                break;
            }
        }

        Count = 0;

        yield return new WaitForSeconds(0.3f);

        while (true)
        {
            yield return null;
            this.gameObject.transform.position += new Vector3(0, 12 * Time.deltaTime, 0);
            Count += 12 * Time.deltaTime;

            if (Count >= 30)
            {
                Debug.Log("asd");
                break;
            }
        }

        StartCoroutine(LoopTitle());
    }

    IEnumerator TitleWait()
    {
        yield return null;
        StartCoroutine(FadeIn(FadePan));
    }

    IEnumerator FadeIn(GameObject ObjColor)
    {
        ObjColor.gameObject.SetActive(true);

        Color color = ObjColor.GetComponent<RawImage>().color;
        float i = 0;

        while (true)
        {

            yield return new WaitForSeconds(0.007f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.GetComponent<RawImage>().color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }

        SceneManager.LoadScene("MoveScene");
    }
}

