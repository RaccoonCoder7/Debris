using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Button pauseButton;
    public Button resumeButton;
    public Button returnButton;
    public GameObject pausePanel;
    public Timer timer;
    public float timeLimit;

    private enum SelectedColor
    {
        None = 0,
        Red = 1 << 0,
        Green = 1 << 1,
        Blue = 1 << 2,
        All = int.MaxValue
    };
    private SelectedColor selectedColor;


    public void ReturnResult(bool isSuccess)
    {
        if (isSuccess)
        {
            GameMgr.In.clearedEvent[GameMgr.In.EventNumber] = isSuccess;
        }

        SceneManager.LoadScene("MoveScene");
    }

    private void Start()
    {
        topPiece.button.onClick.AddListener(OnClickTopButton);
        leftPiece.button.onClick.AddListener(OnClickLeftButton);
        rightPiece.button.onClick.AddListener(OnClickRightButton);
        middlePiece.button.onClick.AddListener(OnClickMiddleButton);
        redButton.onClick.AddListener(OnClickRedButton);
        greenButton.onClick.AddListener(OnClickGreenButton);
        blueButton.onClick.AddListener(OnClickBlueButton);
        pauseButton.onClick.AddListener(OnClickPauseButton);
        resumeButton.onClick.AddListener(OnClickResumeButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
        timer.StartTimer(this, timeLimit);
    }

    private void OnClickPauseButton()
    {
        pausePanel.SetActive(true);
        timer.PauseTimer();
    }

    private void OnClickResumeButton()
    {
        pausePanel.SetActive(false);
        timer.ResumeTimer();
    }

    private void OnClickReturnButton()
    {
        ReturnResult(false);
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
        // TestCode
        ReturnResult(true);
        return;
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
        selectedPiece.button.image.color = GetColor(selectedPiece.button);

        foreach (var piece in selectedPiece.connectedPieceList)
        {
            piece.button.image.color = GetColor(piece.button);
        }
    }

    private Color GetColor(Button targetButton)
    {
        if (selectedColor == SelectedColor.None)
        {
            return Color.black;
        }

        var btnColor = targetButton.image.color;
        bool isRed = ((selectedColor & SelectedColor.Red) != 0) || btnColor.r != 0;
        bool isGreen = ((selectedColor & SelectedColor.Green) != 0) || btnColor.g != 0;
        bool isBlue = ((selectedColor & SelectedColor.Blue) != 0) || btnColor.b != 0;
        Color result = new Color(
            isRed ? 1 : 0,
            isGreen ? 1 : 0,
            isBlue ? 1 : 0
        );

        return result;
    }

    [ContextMenu("Test")]
    private void Test()
    {
        float tmpTime = Mathf.Ceil(timeLimit);
        int minute = (int)tmpTime / 60;
        int second = (int)tmpTime % 60;

        Debug.Log($"{minute:00}:{second:00}");
    }
}
