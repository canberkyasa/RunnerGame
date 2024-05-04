using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }
    public int wood { get; private set; }
    public int collectiblePoints { get; private set; }
    public Color color { get; private set; }= Color.NoColor;
    [SerializeField] private Color startingColor = Color.NoColor;

    public enum Color
    {
        Red,
        Yellow,
        Blue,
        NoColor
    }

    private void Start()
    {
        color = startingColor;
    }

    private void Update()
    {
        //Debug.Log(color.ToString()+" : " + collectiblePoints.ToString());
    }

    //GEM
    private void IncrementScore(int x) { score += x; }
    public void DecreaseScore() { score--; }
    
    //COLLECTIBLE
    private void IncrementCollectible() { collectiblePoints++; }
    private void DecreaseCollectible(GameController.Color newColor)
    {
        if (collectiblePoints > 0) { collectiblePoints--;}
        else if (collectiblePoints == 0 && color != newColor)
        {
            color = newColor;

            EventManager.OnSetColor(color);
            EventManager.OnChangeColor(color); //Splash effects and other stuff.
        }
    }
    private void SetColor(Color newColor) { color = newColor; }

    //PLANK
    private void IncrementWood() { wood++;}
    private void DecreaseWood() { wood--; }

    private void OnEnable()
    {
        EventManager.IncrementScore += IncrementScore;
        EventManager.IncrementWood += IncrementWood;
        EventManager.IncrementCollectiblePoints += IncrementCollectible;
        EventManager.DecrementCollectiblePointsORChangeColor += DecreaseCollectible;
        EventManager.SetColor += SetColor;
    }
    private void OnDisable()
    {
        EventManager.IncrementScore -= IncrementScore;
        EventManager.IncrementWood -= IncrementWood;
        EventManager.IncrementCollectiblePoints -= IncrementCollectible;
        EventManager.DecrementCollectiblePointsORChangeColor -= DecreaseCollectible;
        EventManager.SetColor -= SetColor;
    }
}
