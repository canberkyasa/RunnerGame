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
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gameController = FindObjectOfType<GameController>();
        scoreText.text = gameController.score.ToString();
        
    }
    // PRIVATE YAP!!!!
    public void UpdateScore()
    {
        Debug.Log("Score Updated");
        scoreText.text = gameController.score.ToString();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    private void OnEnable()
    {
        EventManager.GemCollected += UpdateScore;
        EventManager.GameOver += GameOver;
    }

    private void OnDisable()
    {
        EventManager.GemCollected -= UpdateScore;
        EventManager.GameOver -= GameOver;
    }
}
