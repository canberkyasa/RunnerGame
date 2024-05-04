using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameController.Color playerColor;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material blueMaterial;


    public string GetColor() => playerColor.ToString();
    
    // Start is called before the first frame update
    void Start()
    {
        switch (playerColor)
        {
            case GameController.Color.Red:
                GetComponent<Renderer>().material = redMaterial;
                break;
            case GameController.Color.Yellow:
                GetComponent<Renderer>().material = yellowMaterial;
                break;
            case GameController.Color.Blue:
                GetComponent<Renderer>().material = blueMaterial;
                break;
            case GameController.Color.NoColor:
                break;
            default:
                Debug.LogError("Invalid color");
                break;
        }
    }

    private void SetColor(GameController.Color newColor)
    {
        playerColor = newColor;
        switch (playerColor)
        {
            case GameController.Color.Red:
                GetComponent<Renderer>().material = redMaterial;
                break;
            case GameController.Color.Yellow:
                GetComponent<Renderer>().material = yellowMaterial;
                break;
            case GameController.Color.Blue:
                GetComponent<Renderer>().material = blueMaterial;
                break;
            case GameController.Color.NoColor:
                break;
            default:
                Debug.LogError("Invalid color");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        EventManager.SetColor += SetColor;
    }
    private void OnDisable()
    {
        EventManager.SetColor -= SetColor;
    }
}
