using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketSceneMgr : MonoBehaviour
{
    public RawImage FadePan;

    public List<StagePart> StageRocketPart;

    public List<GameObject> StageRocketImg;

    public GameObject EndingImg;

    public GameObject FireBtn;

    private int StageNum = GameMgr.In.Stage - 1;
    
    // Start is called before the first frame update 
    void Start() 
    {
        StartCoroutine(FadeOut(FadePan));

        // SoundMgr.In.PlayLoopSound("6_MainMenuTheme");

        TypeSetting();
        ActiveImg();

        //RocketImg.texture = StageRocketPart[0].RocketPart[0];
    }

    void TypeSetting()
    {
        if(GameMgr.In.Stage <= 2)
        {
            StageRocketPart[StageNum].StageType.SetActive(true);
        }

        if(GameMgr.In.Stage <= 2)
        {
            StageRocketImg[StageNum].SetActive(true);
        }

        else
        {
            EndingImg.SetActive(true);
        }
    }

    public void FireRocket()
    {
        SoundMgr.In.PlaySound("4_button");

        GameMgr.In.PlayerPos = GameMgr.In.BasicPlayerPos;
        GameMgr.In.CameraPos = GameMgr.In.BasicCameraPos;

        StartCoroutine(FadeInEnding(FadePan));
    }

    public void AcriveMoveScene()
    {
        SoundMgr.In.PlaySound("4_button");

        StartCoroutine(FadeInMoveScene(FadePan));
    }

    void ActiveImg()
    {
        int FireCheck = 0;

        if (StageRocketPart[StageNum].StageType.name == "Type1" && GameMgr.In.Stage <= 2)
        {
            if (GameMgr.In.clearedEvent[0] == true)
            {
                StageRocketPart[StageNum].Part[0].texture = StageRocketPart[StageNum].RocketPart[0];
                FireCheck += 1;
            }

            if (GameMgr.In.clearedEvent[1] == true)
            {
                StageRocketPart[StageNum].Part[1].texture = StageRocketPart[StageNum].RocketPart[1];
                FireCheck += 1;
            }

            if (FireCheck == 2)
            {
                FireBtn.SetActive(true);
            }
        }

        else if (StageRocketPart[StageNum].StageType.name == "Type2" && GameMgr.In.Stage <= 2)
        {
            if (GameMgr.In.clearedEvent[2] == true)
            {
                StageRocketPart[StageNum].Part[0].texture = StageRocketPart[StageNum].RocketPart[0];
                FireCheck += 1;
            }

            if (GameMgr.In.clearedEvent[3] == true)
            {
                StageRocketPart[StageNum].Part[1].texture = StageRocketPart[StageNum].RocketPart[1];
                FireCheck += 1;
            }

            if (GameMgr.In.clearedEvent[4] == true)
            {
                StageRocketPart[StageNum].Part[2].texture = StageRocketPart[StageNum].RocketPart[2];
                FireCheck += 1;
            }

            if (FireCheck == 3)
            {
                FireBtn.SetActive(true);
            }
        }
    }

    IEnumerator FadeInEnding(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 0;

        while (true)
        {
            yield return new WaitForSeconds(0.007f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }
        SceneManager.LoadScene("EndingScene");
    }

    IEnumerator FadeInMoveScene(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 0;

        while (true)
        {

            yield return new WaitForSeconds(0.007f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }
        SceneManager.LoadScene("MoveScene");
    }

    IEnumerator FadeOut(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 1;

        while (true)
        {

            yield return new WaitForSeconds(0.007f);

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
