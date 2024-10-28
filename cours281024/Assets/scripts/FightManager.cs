using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] public GameObject aiturn;
    [SerializeField] public GameObject playerturn;
    
    
    [SerializeField] public GameObject escapeMenu;
    [SerializeField] public GameObject ennemyEscapeMenu;
    
    
    [SerializeField] public GameObject loseMenu;
    [SerializeField] public GameObject WinMenu;
    
    
    [SerializeField] public Slider PhealthSlider;
    [SerializeField] public Slider AihealthSlider;
    
    
    [SerializeField] public TMP_Text PlayerHP;
    [SerializeField] public TMP_Text AiHP;

    
    private int playerHp = 100;
    private int aiHp = 100;

    private int fireATK = 15;
    private int waterATK = 10;
    private int heal = 50;
    
    //----------------------------------------------------------------------
    
    public enum GameState
    {
        aiturn,
        playerturn
    }

    public GameState m_currentGameState = GameState.playerturn;

    public void ChangeGameState(GameState newGameState)
    {
        switch (m_currentGameState)
        {
            case GameState.aiturn: DisableAI();
                break;
            case GameState.playerturn: DisablePlayer();
                break;
        }
        
        m_currentGameState = newGameState;
        
        switch (newGameState)
        {
            case GameState.aiturn: SetUpAI();
                break;
            case GameState.playerturn: SetUpPlayer();
                break;
        }
    }

    public void DisableAI()
    {
        aiturn.SetActive(false);
    }
    public void DisablePlayer()
    {
        playerturn.SetActive(false);
    }
    public void SetUpPlayer()
    {
        playerturn.SetActive(true);
    }
    public void SetUpAI()
    {
        aiturn.SetActive(true);
    }

    //--------------------| ATK |---------------------------
    
    public void PlayerFireATK()
    {
         aiHp -= fireATK;
         aiHp = Mathf.Clamp(aiHp,  0,  100);
         AihealthSlider.value = aiHp;
         AiHP.text = aiHp.ToString();
         DisablePlayer();
         SetUpAI();
         
         
    }
    public void AiFireATK()
    {
        playerHp -= fireATK;
        playerHp = Mathf.Clamp(playerHp,  0,  100);
        PhealthSlider.value = playerHp;
        PlayerHP.text = playerHp.ToString();
        DisableAI();
        SetUpPlayer();
        
        
    }

    public void PlayerWaterATK()
    {
        aiHp -= waterATK;
        aiHp = Mathf.Clamp(aiHp,  0,  100);
        AihealthSlider.value = aiHp;
        AiHP.text = aiHp.ToString();
        DisablePlayer();
        SetUpAI();
    }
    public void AiWaterATK()
    {
        playerHp -= waterATK;
        playerHp = Mathf.Clamp(playerHp,  0,  100);
        PhealthSlider.value = playerHp;
        PlayerHP.text = playerHp.ToString();
        DisableAI();
        SetUpPlayer();
    }

    public void PlayerHeal()
    {
        playerHp += heal;
        playerHp = Mathf.Clamp(playerHp,  0,  100);
        PhealthSlider.value = playerHp;
        PlayerHP.text = playerHp.ToString();
        DisablePlayer();
        SetUpAI();
    }
    public void AiHeal()
    {
        aiHp += heal;
        aiHp = Mathf.Clamp(aiHp,  0,  100);
        AihealthSlider.value = aiHp;
        AiHP.text = aiHp.ToString();
        DisableAI();
        SetUpPlayer();
    }

    public void SetUpPlayerEscapeMenu()
    {
        playerturn.SetActive(false);
        escapeMenu.SetActive(true);
    }
    
    public void SetUpEnnemyEscapeMenu()
    {
        aiturn.SetActive(false);
        ennemyEscapeMenu.SetActive(true);
    }

    //-------------------------------------------------------
    
    public void PlayerRetry()
    {
        escapeMenu.SetActive(false);
        WinMenu.SetActive(false);
        loseMenu.SetActive(false);
        playerHp = 100;
        aiHp = 100;
        PhealthSlider.value = 100;
        AihealthSlider.value = 100;
        PlayerHP.text = playerHp.ToString();
        AiHP.text = aiHp.ToString();
        playerturn.SetActive(true);
    }
    public void EnnemyRetry()
    {
        ennemyEscapeMenu.SetActive(false);
        WinMenu.SetActive(false);
        loseMenu.SetActive(false);
        playerHp = 100;
        aiHp = 100;
        PhealthSlider.value = 100;
        AihealthSlider.value = 100;
        PlayerHP.text = playerHp.ToString();
        AiHP.text = aiHp.ToString();
        playerturn.SetActive(true);
    }
    
    //----------------------| PV |------------------------------------

    public void Update()
    {
        if (aiHp <= 0)
        {
            playerturn.SetActive(false);
            aiturn.SetActive(false);
            WinMenu.SetActive(true);
        }
        else if (playerHp <= 0)
        {
            playerturn.SetActive(false);
            aiturn.SetActive(false);
            loseMenu.SetActive(true);
        }
    }
    
}
