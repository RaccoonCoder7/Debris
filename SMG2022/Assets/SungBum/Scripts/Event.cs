using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    [SerializeField]
    string EventName;

    [SerializeField]
    bool EventChk = false;

    [SerializeField]
    RawImage FadePan;

    // Start is called before the first frame update
    void Start()
    {
        EventName = this.gameObject.name;
    }

    private void Update()
    {
        if(EventChk)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("asd");

                GameMgr.In.PlayerPos = GameObject.Find("Player").transform.position;
                SendEventNum();

                StartCoroutine(FadeIn(FadePan));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            EventChk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventChk = false;
        }
    }

    void SendEventNum()
    {
        int SecondIdx = 1;

        string[] EventNumberArr = EventName.Split('_');

        GameMgr.In.EventNumber = int.Parse(EventNumberArr[SecondIdx]);
    }

    IEnumerator FadeIn(RawImage ObjColor)
    {
        ObjColor.gameObject.SetActive(true);
        Color color = ObjColor.color;
        float i = 0;

        while (true)
        {
            Debug.Log(i);

            yield return new WaitForSeconds(0.007f);

            i += Time.deltaTime;
            color.a = i;
            ObjColor.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }

        SceneManager.LoadScene("GameScene");
    }
}
