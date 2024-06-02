using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneMgr : MonoBehaviour
{
    public RawImage FadePan;

    public List<GameObject> EndingStory;

    public GameObject EndingImg;

    public GameObject NextBtn;
    public GameObject StoryNextBtn;

    public Text NextTxt;
    public Text StoryNextTxt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut(FadePan));

        SoundMgr.In.PlayLoopSound("7_EndingTheme");

        StartCoroutine(AlphaDown(NextTxt));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveEndingStoryScene()
    {
        EndingStory[GameMgr.In.Stage - 1].SetActive(true);
        NextBtn.gameObject.SetActive(false);
        StoryNextBtn.gameObject.SetActive(true);
        StartCoroutine(AlphaDown(StoryNextTxt));
    }

    public void ActiveMoveScene()
    {
        GameMgr.In.Stage++;
        StartCoroutine(FadeIn(FadePan));
    }

    IEnumerator AlphaDown(Text ObjColor)
    {
        Color color = ObjColor.color;
        float i = 0;

        while(true)
        {
            Debug.Log(i);

            yield return new WaitForSeconds(0.01f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if(i >= 1.0f)
            {
                break;
            }
        }
    }

    IEnumerator FadeIn(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 0;

        while (true)
        {
            Debug.Log(i);

            yield return new WaitForSeconds(0.002f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }

        SoundMgr.In.StopBGM();
        SceneManager.LoadScene("MoveScene");
    }

    IEnumerator FadeOut(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 1;

        while (true)
        {
            Debug.Log(i);

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
