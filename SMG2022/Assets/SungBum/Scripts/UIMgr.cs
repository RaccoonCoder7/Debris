using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMgr : MonoBehaviour
{
    [SerializeField]
    GameObject StoryTxt;

    [SerializeField]
    GameObject InformationTxt;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    RawImage FadePan;

    public RawImage BackGround;

    public List<Texture> BackGrounds;

    private void Start()
    {
        StartCoroutine(FadeOut(FadePan));

        Player = GameObject.Find("Player");

        if((GameMgr.In.Stage - 1) > 0)
            BackGround.texture = BackGrounds[GameMgr.In.Stage - 1];
    }

    public void ActiveStoryTxt()
    {
        SoundMgr.In.PlaySound("4_button");

        if(StoryTxt.active == false)
        {
            StoryTxt.SetActive(true);
        }

        else
        {
            StoryTxt.SetActive(false);
        }
    }

    public void ActiveInformationTxt()
    {
        SoundMgr.In.PlaySound("4_button");

        if (InformationTxt.active == false)
        {
            InformationTxt.SetActive(true);
        }

        else
        {
            InformationTxt.SetActive(false);
        }
    }

    public void AcriveRocketScene()
    {
        SoundMgr.In.PlaySound("4_button");

        GameMgr.In.PlayerPos = Player.transform.position;
        GameMgr.In.CameraPos = GameObject.Find("Main Camera").transform.position;
        StartCoroutine(FadeIn(FadePan));
    }

    IEnumerator FadeIn(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 0;

        while (true)
        {

            yield return new WaitForSeconds(0.002f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }

        SceneManager.LoadScene("RocketScene");
    }

    IEnumerator FadeOut(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 1;

        while (true)
        {
            yield return new WaitForSeconds(0.002f);

            i -= Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i <= 0.0f)
            {
                break;
            }
        }

        ObjColor.gameObject.SetActive(false);
    }
}
