using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }
    public int wood { get; private set; }

    //GEM
    public void IncrementScore(int x) { score += x; }
    public void DecreaseScore() { score--; }
    
    //PLANK
    public void IncrementWood() { wood++;}
    public void DecreaseWood() { wood--; }

    private void OnEnable()
    {
        EventManager.IncrementScore += IncrementScore;
        EventManager.IncrementWood += IncrementWood;
    }
    private void OnDisable()
    {
        EventManager.IncrementScore -= IncrementScore;
        EventManager.IncrementWood -= IncrementWood;
    }
}
