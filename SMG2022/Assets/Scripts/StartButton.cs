using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    public bool Startbutton;
    public void StartButtonClick()
    {
        transform.DOMoveY(-625, 0.9f).SetEase(Ease.InBack);
        Startbutton = true;
    }

}

