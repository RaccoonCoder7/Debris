using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public PieceData topPiece;
    public PieceData leftPiece;
    public PieceData rightPiece;
    public PieceData middlePiece;
    public Button redButton;
    public Button greenButton;
    public Button blueButton;

    private enum SelectedColor
    {
        None = 0,
        Red = 1 << 0,
        Green = 1 << 1,
        Blue = 1 << 2,
        All = int.MaxValue
    };
    private SelectedColor selectedColor;

    private void Start()
    {
        topPiece.button.onClick.AddListener(OnClickTopButton);
        leftPiece.button.onClick.AddListener(OnClickLeftButton);
        rightPiece.button.onClick.AddListener(OnClickRightButton);
        middlePiece.button.onClick.AddListener(OnClickMiddleButton);
        redButton.onClick.AddListener(OnClickRedButton);
        greenButton.onClick.AddListener(OnClickGreenButton);
        blueButton.onClick.AddListener(OnClickBlueButton);
    }

    private void OnClickTopButton()
    {
        SetPuzzleColor(topPiece);
    }

    private void OnClickLeftButton()
    {
        SetPuzzleColor(leftPiece);
    }

    private void OnClickRightButton()
    {
        SetPuzzleColor(rightPiece);
    }

    private void OnClickMiddleButton()
    {
        SetPuzzleColor(middlePiece);
    }

    private void OnClickRedButton()
    {
        SetColorButtonColor(redButton, SelectedColor.Red);
    }

    private void OnClickGreenButton()
    {
        SetColorButtonColor(greenButton, SelectedColor.Green);
    }

    private void OnClickBlueButton()
    {
        SetColorButtonColor(blueButton, SelectedColor.Blue);
    }

    private void SetColorButtonColor(Button btn, SelectedColor color)
    {
        bool isSelected = (selectedColor & color) != 0;
        var currentColor = btn.image.color;

        if (isSelected)
        {
            selectedColor &= ~color;
            currentColor.a = 0.5f;
        }
        else
        {
            selectedColor |= color;
            currentColor.a = 1;
        }

        btn.image.color = currentColor;
    }

    private void SetPuzzleColor(PieceData selectedPiece)
    {
        Color resultColor = Color.black;
        selectedPiece.button.image.color = new Color(
            (float)(selectedColor & SelectedColor.Red),
            (float)(selectedColor & SelectedColor.Green),
            (float)(selectedColor & SelectedColor.Blue)
        );

        foreach (var piece in selectedPiece.connectedPieceList)
        {
            piece.button.image.color = resultColor;
        }
    }
}
