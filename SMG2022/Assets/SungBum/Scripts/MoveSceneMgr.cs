using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneMgr : MonoBehaviour
{
    public List<GameObject> EventObj;

    public List<GameObject> StageObj;

    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.In.PlayLoopSound("6_MainMenuTheme");

        int EventIdx = 0;

        foreach(GameObject Obj in EventObj)
        {
            if(GameMgr.In.clearedEvent[EventIdx] == true)
            {
                Obj.SetActive(false);
            }

            EventIdx++;
        }

        StageObj[GameMgr.In.Stage - 1].SetActive(true);
    }
}
