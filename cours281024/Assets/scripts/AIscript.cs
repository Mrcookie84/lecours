using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    
    public enum AIState
    {
        loosing,
        winning, 
    }

    public AIState m_currentAIState = AIState.winning;
        
    public void DetermineState(int hp)
    {
        m_currentAIState = hp < 30 ? AIState.loosing : AIState.winning;
    }
        
    public void ManageAITurn()
    {
        switch (m_currentAIState )
        {
            case AIState.loosing:ManageLoosing(); 
                break;
            case AIState.winning: ManageWinning(); 
                break;
            default: throw new ArgumentOutOfRangeException();
        }   
    }

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        if (rand> 85)
        {
            RunAway();
            return;
        } 
        
        if(rand > 50)
        {
            Heal();
            return;
        }
     
        Attack();
    }

    public void Attack()
    {
        // AI attacks
    }
    
    public void Heal()
    {
        // IA Heals its monster
    }
    
    public void RunAway()
    {
        // IA QUITS FIGHT
    }
    
    public void ManageWinning()
    {
        
    }
    
}