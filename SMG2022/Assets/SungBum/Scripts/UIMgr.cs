using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMgr : MonoBehaviour
{
    [SerializeField]
    GameObject StoryTxt;

    [SerializeField]
    GameObject InformationTxt;

    [SerializeField]
    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void ActiveStoryTxt()
    {
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
        if (InformationTxt.active == false)
        {
            Debug.Log("open");
            InformationTxt.SetActive(true);
        }

        else
        {
            Debug.Log("close");
            InformationTxt.SetActive(false);
        }
    }

    public void AcriveRocketScene()
    {
        GameMgr.In.PlayerPos = Player.transform.position;
        SceneManager.LoadScene("RocketScene");
    }

    public void AcriveMoveScene()
    {
        SceneManager.LoadScene("MoveScene");
    }
}
