using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private GameController.Color collectibleColor;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material blueMaterial;

    
    void Start()
    {
        switch (collectibleColor)
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
            default:
                Debug.LogError("Invalid color");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (other.GetComponent<PlayerScript>().GetColor() == collectibleColor.ToString())
        {
            EventManager.OnCollectibleCollected();
            EventManager.OnIncrementCollectiblePoints();
        }
        else
        {
            EventManager.OnDecrementCollectiblePointsORChangeColor(collectibleColor); //Decrese points or change color
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos() //Deactivate when Build
    {
        Gizmos.color = collectibleColor switch
        {
            GameController.Color.Red => Color.red,
            GameController.Color.Yellow => Color.yellow,
            GameController.Color.Blue => Color.blue,
            _ => Color.white
        };

        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
