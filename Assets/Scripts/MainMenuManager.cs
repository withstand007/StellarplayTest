using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel, gamePanel;
    public GameManager gameManager;
    public Text highScoreText;

    public int highScore
    {
        get => PlayerPrefs.GetInt("highscore",0);
        set => PlayerPrefs.SetInt("highscore", value);
    }

    private void Start()
    {
        highScoreText.text = highScore.ToString();
    }

    public void OnPlayButtonClicked()
    {
        ToggleGamePanel(true);
        gameManager.StartGame();
    }

    public void OnBackButtonClicked()
    {
        highScoreText.text = highScore.ToString();
        ToggleGamePanel(false);
    }

    void ToggleGamePanel(bool shouldShow)
    {
        gamePanel.SetActive(shouldShow);
        mainPanel.SetActive(!shouldShow);
    }
}
