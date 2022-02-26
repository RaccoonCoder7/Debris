using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceData : MonoBehaviour
{
    [HideInInspector]
    public Button button;
    public List<PieceData> connectedPieceList = new List<PieceData>();
    public Color goalColor = Color.black;
    public bool isSuccess
    {
        get {
            return goalColorCode.Equals(ColorUtility.ToHtmlStringRGB(currentColor));
        }
    }

    private Color currentColor = Color.gray;
    private string goalColorCode;

    public void SetColor(Color color)
    {
        currentColor = color;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        goalColorCode = ColorUtility.ToHtmlStringRGB(goalColor);
    }
}
