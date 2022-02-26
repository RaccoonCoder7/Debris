using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneMgr : MonoBehaviour
{
    public List<GameObject> EventObj;

    // Start is called before the first frame update
    void Start()
    {
        int EventIdx = 0;

        foreach(GameObject Obj in EventObj)
        {
            if(GameMgr.In.ClerclearedEvent[EventIdx] == true)
            {
                Obj.SetActive(false);
            }

            EventIdx++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
