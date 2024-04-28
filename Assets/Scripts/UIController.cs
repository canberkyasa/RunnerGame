using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        scoreText.text = gameController.score.ToString();
        
    }

    public void UpdateScore()
    {
        scoreText.text = gameController.score.ToString();
    }

}
