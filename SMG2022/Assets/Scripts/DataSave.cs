using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DataSave : MonoBehaviour
{
    public GameObject Player;
    GameMgr GameMgr;
    bool Stage1;
  

   
    void Start()
    {
        GameMgr = GetComponent<GameMgr>();
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX",Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY",Player.transform.position.y);
        PlayerPrefs.SetInt("ClearStage", GameMgr.clearedEvent[0].Toint16());
        PlayerPrefs.SetInt("ClearStage", GameMgr.clearedEvent[1].Toint16());
        PlayerPrefs.SetInt("ClearStage", GameMgr.clearedEvent[2].Toint16());
        PlayerPrefs.SetInt("ClearStage", GameMgr.clearedEvent[3].Toint16());
        PlayerPrefs.SetInt("ClearStage", GameMgr.clearedEvent[4].Toint16());
    }
    public void GameLoad()
    {
        
    }

}
