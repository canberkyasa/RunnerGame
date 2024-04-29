using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }

    public void IncrementScore() //first listener
    {
        score++;
    }
    public void DecreaseScore() //second listener
    {
        score--;
    }
}
