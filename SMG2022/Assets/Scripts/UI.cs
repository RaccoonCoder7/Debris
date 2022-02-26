using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{
    public bool Startbutton;
    public GameObject Title;
    void Start()
    {

        Title.transform.DOLocalMoveY(170, 1.5f).SetLoops(-1, LoopType.Yoyo);


    }
    public void StartButtonClick()
    {
        transform.DOMoveY(-625, 0.9f).SetEase(Ease.InBack);
        StartCoroutine(TitleWait());
    }
    public void TitleMove()
    {
        transform.DOMoveY(1500, 1.1f).SetEase(Ease.InBack);
    }
    public void Clear()
    {
        StartCoroutine(ClearWait());
    }
    IEnumerator ClearWait()
    {
        yield return new WaitForSeconds(1f);
        transform.DOMoveX(960, 1.1f).SetEase(Ease.InQuad);
    }
    IEnumerator TitleWait()
    {
        yield return new WaitForSeconds(0.9f);
        Title.SetActive(false);
        Startbutton = true;
    }
}

