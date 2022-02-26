using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : SingletonMono<GameMgr>
{
    public Vector3 PlayerPos;
    public Vector3 BasicPlayerPos;

    public Vector3 CameraPos;
    public Vector3 BasicCameraPos;

    public int Stage = 1;

    public int EventNumber = 0;
    public GameObject Player;

    [SerializeField]
    int Stage1, Stage2, Stage3, Stage4, Stage5;

    private void Start()
    {
        GameLoad();
        Stage1 = clearedEvent[0] ? 1 : 0;
        Stage2 = clearedEvent[1] ? 1 : 0;
        Stage3 = clearedEvent[2] ? 1 : 0;
        Stage4 = clearedEvent[3] ? 1 : 0;
        Stage5 = clearedEvent[4] ? 1 : 0;
    }
    public List<bool> clearedEvent = new List<bool>(new bool[]
        {
            false,
            false,
            false,
            false,
            false
        }
    );
    private void OnApplicationPause()
    {
        GameSave();
    }
    protected override void OnApplicationQuit()
    {
        GameSave();
    }

    public void GameSave()
    {
        //데이터 저장하기
        PlayerPrefs.SetInt("ClearStage1", Stage1);
        PlayerPrefs.SetInt("ClearStage2", Stage2);
        PlayerPrefs.SetInt("ClearStage3", Stage3);
        PlayerPrefs.SetInt("ClearStage4", Stage4);
        PlayerPrefs.SetInt("ClearStage5", Stage5);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("ClearStage1"))
        {
            return;
        }
        Stage1 = PlayerPrefs.GetInt("ClearStage1");
        Stage2 = PlayerPrefs.GetInt("ClearStage2");
        Stage3 = PlayerPrefs.GetInt("ClearStage3");
        Stage4 = PlayerPrefs.GetInt("ClearStage4");
        Stage5 = PlayerPrefs.GetInt("ClearStage5");//저장 값 불러오기

        if (Stage1 == 1)//실제로 값 대입하기
        {
            clearedEvent[0] = true;
        }
        else
        {
            clearedEvent[0] = false;
        }
        if (Stage2 == 1)
        {
            clearedEvent[1] = true;
        }
        else
        {
            clearedEvent[1] = false;
        }
        if (Stage3 == 1)
        {
            clearedEvent[2] = true;
        }
        else
        {
            clearedEvent[2] = false;
        }
        if (Stage4 == 1)
        {
            clearedEvent[3] = true;
        }
        else
        {
            clearedEvent[3] = false;
        }
        if (Stage5 == 1)
        {
            clearedEvent[4] = true;
        }
        else
        {
            clearedEvent[4] = false;
        }
        //너무 더럽네 ㄹㅇㅋㅋ
    }
}
