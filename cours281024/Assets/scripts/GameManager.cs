using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject game;
    
    
    
    public enum GameState
    {
        Menu,
        Game
    }

    public GameState m_currentGameState = GameState.Menu;

    public void ChangeGameState(GameState newGameState)
    {
        switch (m_currentGameState)
        {
            case GameState.Menu:DisableMenu();
                break;
            case GameState.Game: DisableGame();
                break;
        }
        
        m_currentGameState = newGameState;
        
        switch (newGameState)
        {
            case GameState.Menu: SetUpMenu();
                break;
            case GameState.Game: SetUpGame();
                break;
        }
    }

    public void DisableMenu()
    {
        menu.SetActive(false);
    }
    public void DisableGame()
    {
        game.SetActive(false);
    }
    public void SetUpGame()
    {
        game.SetActive(true);
    }
    public void SetUpMenu()
    {
        menu.SetActive(true);
    }
    
}
