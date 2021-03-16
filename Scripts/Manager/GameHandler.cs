using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    InBuildingController,
    InShop,
    InGame,   
}
public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance => instance;
    private static GameHandler instance;

    public UnityAction<GameState, GameState> OnGameSateChange;
    public GameState gameState;

 
    private void Start()
    {
        instance = this;
        

    }
    public void ChangeGameState(GameState newState)
    {
        GameState oldGameState = gameState;
        gameState = newState;
        OnGameSateChange?.Invoke(oldGameState, gameState);

    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.InBuildingController:
                break;
            case GameState.InShop:
                break;
            case GameState.InGame:
                break;
            default:
                break;

        }

      
    }
}