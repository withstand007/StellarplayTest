using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GAMESTATE currentState;
    private BotPlayer botPlayer;
    private RealPlayer realPlayer;
    private ElementManager elementManager;
    private const float maxPlayerTime = 2f;
    private int totalPoints = 0;


    public Action<GAMESTATE> onGameStateChanged;
    public Text botSelectedText;
    public Image image;
    public MainMenuManager menuManager;





    void Awake()
    {
        elementManager = new ElementManager();
    }

    public void StartGame()
    {
        totalPoints = 0;
        CreateInstance();
    }

    void CreateInstance()
    {
        CreatePlayers();
        realPlayer.onTurnEnded += OnAnyPlayerTurnEnded;
        botPlayer.onTurnEnded += OnAnyPlayerTurnEnded;
        onGameStateChanged += OnGameStateChanged;
        SetCurrentGameState(GAMESTATE.BOTTURN);
    }

    public void CreatePlayers()
    {
        botPlayer = new BotPlayer(elementManager);
        realPlayer = new RealPlayer();
    }

    void UnlinkAllSubscriptions()
    {
        realPlayer.onTurnEnded -= OnAnyPlayerTurnEnded;
        botPlayer.onTurnEnded -= OnAnyPlayerTurnEnded;
        onGameStateChanged -= OnGameStateChanged;
    }

    void OnAnyPlayerTurnEnded()
    {
        switch (currentState)
        {
            case GAMESTATE.BOTTURN:
                SetCurrentGameState(GAMESTATE.PLAYERTURN);
                break;
            case GAMESTATE.PLAYERTURN:
                CheckWhoWon();
                break;
        }
    }

    void CheckWhoWon()
    {
        if (realPlayer.GetCurrentElement().elementType == botPlayer.GetCurrentElement().elementType)
        {
            Debug.LogError("That's a draw :/");
            GameDraw();
        }
        else if (realPlayer.GetCurrentElement().elementType != botPlayer.GetCurrentElement().elementType)
        {
            var temp = realPlayer.GetCurrentElement().canLoseTo;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == botPlayer.GetCurrentElement().elementType)
                {
                    Debug.LogError("Thats so sad, our player lost :(");
                    GameLost();
                    return;
                }
            }
            Debug.LogError("Yayyy me won!!");
            GameWon();
        }
    }

    void GameDraw()
    {
        UnlinkAllSubscriptions();
        menuManager.OnBackButtonClicked();
    }

    void GameWon()
    {
        totalPoints += 1;
        if (totalPoints > menuManager.highScore)menuManager.highScore = totalPoints;
        UnlinkAllSubscriptions();
        RestartGame();
    }

    void GameLost()
    {
        UnlinkAllSubscriptions();
        menuManager.OnBackButtonClicked();
        totalPoints = 0;
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        image.fillAmount = 0f;
        CreateInstance();
    }

    void OnGameStateChanged(GAMESTATE obj)
    {
        switch (obj)
        {
            case GAMESTATE.PLAYERTURN:
                realPlayer.OnTurnStarted();
                StartTimer();
                break;
            case GAMESTATE.BOTTURN:
                botPlayer.OnTurnStarted();
                SetBotTextUI();
                break;
        }
    }

    public void OnPlayerSelected(int elementSelected)
    {
        realPlayer.SetCurrentElement(elementManager.allElements.Find(x=>(int)x.GetCurrentElementType() == elementSelected));
    }

    void StartTimer()
    {
        float currentTime = 0f;
        float waitingPeriod = 0.01f;
        StartCoroutine(Timer());
        IEnumerator Timer()
        {
            while (currentTime <= maxPlayerTime)
            {
                currentTime += waitingPeriod;
                yield return new WaitForSeconds(waitingPeriod);
                image.fillAmount = currentTime;
            }
            if(currentTime >= maxPlayerTime)
                if (realPlayer.GetCurrentElement() == null) GameLost();
        }
    }

    void SetBotTextUI()
    {
        botSelectedText.text = botPlayer.GetCurrentElement().elementType.ToString();
    }

    void SetCurrentGameState(GAMESTATE newState)
    {
        currentState = newState;
        onGameStateChanged?.Invoke(newState);
    }
}

public enum GAMESTATE
{
    PLAYERTURN,BOTTURN
}












