using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceData : MonoBehaviour
{
    [HideInInspector]
    public Button button;
    public List<PieceData> connectedPieceList = new List<PieceData>();

    private void Awake()
    {
        button = GetComponent<Button>();
    }
}
