using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool RightMove = false;
    public bool LeftMove = false;

    [SerializeField]
    private float MovePower = 1.0f;

    float MoveX = 0;

    bool SoundOnePlay = true;

    // Update is called once per frame

    private void Start()
    {
        this.gameObject.transform.position = GameMgr.In.PlayerPos;
    }

    void Update()
    {
        PCMove();
    }

    void PCMove()
    {
        MoveX = Input.GetAxisRaw("Horizontal");

        this.gameObject.transform.position += new Vector3(MoveX * MovePower * Time.deltaTime, 0, 0);

        if ((MoveX > 0 || MoveX < 0) && SoundOnePlay == true)
        {
            SoundOnePlay = false;
            StartCoroutine("WalkSound");
        }

        else if(MoveX == 0 && SoundOnePlay == false)
        {
            SoundOnePlay = true;
            StopCoroutine("WalkSound");
        }
    }

    IEnumerator WalkSound()
    {
        Debug.Log("asd");

        SoundMgr.In.PlaySound("walking1");

        yield return new WaitForSeconds(0.5f);

        SoundMgr.In.PlaySound("walking2");

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("WalkSound");
    }

/*
    private void MobileMove()
    {
        if (RightMove)
        {
            MoveX = 1;

            this.gameObject.transform.position += new Vector3(MoveX * MovePower * Time.deltaTime, 0, 0);
        }

        else if (LeftMove)
        {
            MoveX = -1;

            this.gameObject.transform.position += new Vector3(MoveX * MovePower * Time.deltaTime, 0, 0);
        }
    }

    public void PointerRightDown()
    {
        RightMove = true;
    }

    public void PointerLeftDown()
    {
        LeftMove = true;
    }

    public void PointerUp()
    {
        RightMove = false;
        LeftMove = false;
    }
*/
}
