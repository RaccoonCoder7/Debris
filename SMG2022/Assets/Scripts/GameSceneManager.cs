using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public List<EventData> eventDataList = new List<EventData>();
    public Button redButton;
    public Button greenButton;
    public Button blueButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button returnButton;
    public Button helpButton;
    public Button exitHelpButton;
    public Transform puzzleParent;
    public GameObject pausePanel;
    public GameObject helpPanel;
    public GameObject resultPanel;
    public Text resultText;
    public Timer timer;
    public Image goalImage;

    private EventData targetEventData;

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
        timer.PauseTimer();

        if (isSuccess)
        {
            GameMgr.In.clearedEvent[GameMgr.In.EventNumber] = isSuccess;
            resultText.text = "성공";
            SoundMgr.In.PlaySound("2_gameclear");
        }
        else
        {
            resultText.text = "실패";
            SoundMgr.In.PlaySound("3_gameover");
        }

        resultPanel.SetActive(true);
        Invoke("ChangeScene", 2f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MoveScene");
    }

    private void Start()
    {
        var eventData = eventDataList.Find(x => x.eventNumber == GameMgr.In.EventNumber);
        targetEventData = Instantiate(eventData, puzzleParent);
        foreach (var piece in targetEventData.pieceDataList)
        {
            piece.button.onClick.AddListener(delegate { SetPieceColor(piece); });
        }
        redButton.onClick.AddListener(OnClickRedButton);
        greenButton.onClick.AddListener(OnClickGreenButton);
        blueButton.onClick.AddListener(OnClickBlueButton);
        pauseButton.onClick.AddListener(delegate { OnClickPauseButton(pausePanel); });
        resumeButton.onClick.AddListener(delegate { OnClickResumeButton(pausePanel); });
        returnButton.onClick.AddListener(OnClickReturnButton);
        helpButton.onClick.AddListener(delegate { OnClickPauseButton(helpPanel); });
        exitHelpButton.onClick.AddListener(delegate { OnClickResumeButton(helpPanel); });

        goalImage.sprite = targetEventData.goalSprite;
        timer.StartTimer(this, targetEventData.limitTime);

        SoundMgr.In.PlayLoopSound("8_PuzzleTheme");
    }

    private void OnClickPauseButton(GameObject obj)
    {
        obj.SetActive(true);
        timer.PauseTimer();
        SoundMgr.In.PlaySound("4_button");
    }

    private void OnClickResumeButton(GameObject obj)
    {
        obj.SetActive(false);
        timer.ResumeTimer();
        SoundMgr.In.PlaySound("4_button");
    }

    private void OnClickReturnButton()
    {
        SoundMgr.In.PlaySound("4_button");
        ChangeScene();
    }

    private void OnClickRedButton()
    {
        SetColorButtonColor(redButton, SelectedColor.Red);
        SoundMgr.In.PlaySound("4_button");
    }

    private void OnClickGreenButton()
    {
        SetColorButtonColor(greenButton, SelectedColor.Green);
        SoundMgr.In.PlaySound("4_button");
    }

    private void OnClickBlueButton()
    {
        SetColorButtonColor(blueButton, SelectedColor.Blue);
        SoundMgr.In.PlaySound("4_button");
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

    private void SetPieceColor(PieceData selectedPiece)
    {
        Color color = GetColor(selectedPiece.button);
        selectedPiece.button.image.color = color;
        selectedPiece.SetColor(color);

        foreach (var piece in selectedPiece.connectedPieceList)
        {
            Color connectedPieceColor = GetColor(piece.button);
            piece.button.image.color = connectedPieceColor;
            piece.SetColor(connectedPieceColor);
        }

        CheckPuzzleSucceed();
        SoundMgr.In.PlaySound("4_button");
    }

    private Color GetColor(Button targetButton)
    {
        if (selectedColor == SelectedColor.None)
        {
            return Color.black;
        }

        var btnColor = targetButton.image.color;
        bool isRed = ((selectedColor & SelectedColor.Red) != 0) || btnColor.r == 1;
        bool isGreen = ((selectedColor & SelectedColor.Green) != 0) || btnColor.g == 1;
        bool isBlue = ((selectedColor & SelectedColor.Blue) != 0) || btnColor.b == 1;
        Color result = new Color(
            isRed ? 1 : 0,
            isGreen ? 1 : 0,
            isBlue ? 1 : 0
        );

        return result;
    }

    private void CheckPuzzleSucceed()
    {
        foreach (var piece in targetEventData.pieceDataList)
        {
            if (!piece.isSuccess)
            {
                return;
            }
        }

        ReturnResult(true);
    }
}
