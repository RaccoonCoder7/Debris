using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketSceneMgr : MonoBehaviour
{
    public List<StagePart> StageRocketPart;

    public GameObject FireBtn;

    private int StageNum = GameMgr.In.Stage - 1;
    
    // Start is called before the first frame update 
    void Start() 
    {
        TypeSetting();
        ActiveImg();

        //RocketImg.texture = StageRocketPart[0].RocketPart[0];
    }

    void TypeSetting()
    {
        StageRocketPart[StageNum].StageType.SetActive(true);
    }

    void ActiveImg()
    {
        int FireCheck = 0;

        if (StageRocketPart[StageNum].StageType.name == "Type1")
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

        else if (StageRocketPart[StageNum].StageType.name == "Type2")
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
}
